import sys
from flask_restful import Resource, Api, reqparse
from validators.mainValidator import validate_login_error_messages, validate_unprotected_endpoint
from flask import Flask, make_response, render_template

# Setup the flask service
app = Flask(__name__)
api = Api(app)

# Global parameter to decide if the task was done
fulfilledTaskTMI = False
fulfilledTaskGET = True
vulnMachineLocation = "http://animalshelter.hkn:8080"
vulnAPILocation = "http://api.animalshelter.hkn:5000"

# -== Helper functions ==-

# Function to return file and mime-type, as a Flask response
# Note: File has to be in ./templates folder
def MakeResponse(fileLocation, mimeType):
    # Make a response for Flask using its render_template functionality
    response = make_response(render_template(fileLocation))

    # Set the mime-type of the response, so that the browser knows how to handle the response
    response.headers["Content-Type"] = mimeType
    return response

# -== Endpoint functionality ==-

# The / endpoint, which displays the frontpage
class Root(Resource):
    def get(self):
        return MakeResponse("index.html", "text/html")

# The /start endpoint, which is responsible for triggering the validation
class Start(Resource):
    def post(self): # TODO: Multithreading-lock, in order to limit ability to DoS the hosting infrastructure
        # Get the location of the vuln machine
        global vulnMachineLocation
        
        # Validate TMI, and set param if successful
        resultTMI = validate_login_error_messages(vulnMachineLocation)
        if resultTMI == True:
            global fulfilledTaskTMI
            fulfilledTaskTMI = True
        
        # Validate GET, and set param if susccesful
        global vulnAPILocation
        resultGET = validate_unprotected_endpoint(vulnAPILocation)
        if resultGET == True:
            global fulfilledTaskGET
            fulfilledTaskGET = True
            # Return to the user that the validation was successfull -> /done
            return { "failed": False }
        else:    
            return { "failed": True }, 500

# The /done endpoint, which is responsible for giving the flag if the objective was fulfilled
class Done(Resource):
    def get(self):
        # Obtain the global param to see if task was fullfilled, and return appropriate HTML
        global fulfilledTaskTMI
        global fulfilledTaskGET
        if fulfilledTaskTMI or fulfilledTaskGET:
            # Set flags
            if fulfilledTaskTMI:
                flagTMI = sys.argv[1]
            else:
                flagTMI = "You have not solved this one yet :("
            if fulfilledTaskGET:
                flagGET = sys.argv[2]
            else:
                flagGET = "You have not solved this one yet :("

            # Send the HTML to the user, with flags included
            response = make_response(render_template("doneGood.html", flagTMI=flagTMI, flagGET=flagGET))
            response.headers["Content-Type"] = "text/html"
            return response
        else:    
            return MakeResponse("doneBad.html", "text/html")

# The / endpoint, which displays the page letting users know an error occured
class Failed(Resource):
    def get(self):
        return MakeResponse("failed.html", "text/html")

# -== Endpoints ==-
api.add_resource(Root, "/")
api.add_resource(Start, "/start")
api.add_resource(Done, "/done")
api.add_resource(Failed, "/failed")

# -== Start server ==-
if not len(sys.argv) == 3:
    print("[!] ERROR! Please (only) enter two flag as the first parameters")
else:
    # Not threaded Flask, in order to have full control over concurrency ourselves
    app.run(threaded=False, debug=False, port=80, host="0.0.0.0")