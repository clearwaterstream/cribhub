
# Ecobee Auth Flow

* Register with ecobee as a developer

* Create an app in ecobee's developer portal, note the `API_KEY`

* Secure the `API_KEY` in vault, it will be needed

* In cribhub.org, "Link Ecobee Account" should redirect to `GET` https://api.ecobee.com/authorize?response_type=code&client_id=API_KEY&redirect_uri=https://api.cribhub.org/ecobee/user/register&scope=smartRead&state=CRIBHUB_ACCT_ID

* This will redirect (`GET`) to https://api.cribhub.org/ecobee/user/register?code=AUTHORIZATION_CODE&state=CRIBHUB_ACCT_ID&error=IF_ANY&error_description=IF_ANY

  *the auth token is good for 10 mins max, so the call should be made quickly*

* Use the `AUTHORIZATION_CODE` to obtain an access and refresh tokens via `POST` https://api.ecobee.com/token?grant_type=authorization_code&code=AUTHORIZATION_CODE&redirect_uri=https://api.cribhub.org/ecobee/user/register&client_id=API_KEY
  
* parse the access token and the refresh token and use it in subsequent requests

#### more info on [ecobee auth flow](https://www.ecobee.com/home/developer/api/documentation/v1/auth/authz-code-authorization.shtml)
