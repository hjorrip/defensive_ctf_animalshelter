import requests

# Validiate the login error message for TMI
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
    try:
        response = requests.post(f'{domain}/{endpoint}', headers=headers, json=wrong_email_wrong_pw_payload)
        json_response = json.loads(response.text)
        wrong_email_error = json_response['errors']
    except Exception:
        print("[!] Failed login with wrong email")
        return False

    # Make a login request with correct email address
    try:
        response = requests.post(f'{domain}/{endpoint}', headers=headers, json=correct_email_wrong_pw_payload)
        json_response = json.loads(response.text)
        correct_email_error = json_response['errors']
    except Exception:
        print("[!] Failed login with wrong email")
        return False

    # Check the errors, and if they are the same, then the vuln is solved
    if wrong_email_error == correct_email_error:
        return True
    else:
        return False

# Validate that the other endpoint has been locked down
def validate_unprotected_endpoint(domain: str):
    endpoint = 'api/customers'

    headers = {
        'Content-type': 'application/json',
        'Accept': 'application/json'
    }

    # Make a login request with correct email address
    try:
        response = requests.get(f'{domain}/{endpoint}', headers=headers)
    except Exception:
        print("[!] Failed to validate endpoint")
        return False

    # If Unauthorized then challenge is solved (meaning endpoint is still available, but properly locked down)
    if response.status_code == 401:
        return True
    else:
        return False
