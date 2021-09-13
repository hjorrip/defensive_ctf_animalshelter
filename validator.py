import requests
from requests.auth import HTTPBasicAuth
import json


def validate_login_error_messages(domain: str):

    endpoint = 'api/authmanagement/login'

    wrong_email_wrong_pw_payload = {
        'email': 'RobertBBrowderr@theanimalshelter.com',
        'password': 'SuperSecurePassw0rd!',
    }
    correct_email_wrong_pw_payload = {
        'email': 'RobertBBrowder@theanimalshelter.com',
        'password': 'SuperSecurePassw0rd!',
    }
    headers = {
        'Content-type': 'application/json',
        'Accept': 'application/json'
    }


    # Make a login request with wrong email address
    response = requests.post(f'{domain}/{endpoint}', headers=headers, json=wrong_email_wrong_pw_payload)
    json_response = json.loads(response.text)
    wrong_email_error = json_response['errors']

    # Make a login request with correct email address
    response = requests.post(f'{domain}/{endpoint}', headers=headers, json=correct_email_wrong_pw_payload)
    json_response = json.loads(response.text)
    correct_email_error = json_response['errors']

    if wrong_email_error == correct_email_error:
        return True
    else:
        return False


    # print request object
    print(response)



def validate_unprotected_endpoint(domain: str):

    endpoint = 'api/customers'

    headers = {
        'Content-type': 'application/json',
        'Accept': 'application/json'
    }

    # Make a login request with correct email address
    response = requests.get(f'{domain}/{endpoint}', headers=headers)

    # If Unauthorized then challenge is solved (meaning endpoint is still available, but properly locked down)
    if response.status_code == 401:
        return True
    else:
        return False



if __name__ == "__main__":
    DOMAIN = "http://localhost:5000"

    login_challenge_solved = validate_login_error_messages(DOMAIN)
    print(f"Login error message challenge solved: {login_challenge_solved}")

    open_endpoint_solved = validate_unprotected_endpoint(DOMAIN)
    print(f"Unprotected endpoint challenge solved: {open_endpoint_solved}")


