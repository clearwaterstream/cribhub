
# ecobee Auth Flow

1. Register with ecobee as a developer
2. Create an app in ecobee's developer portal, note the API key
3. Secure the API key in vault, it will be needed
4. In cribhub.org, "Link ecobee Account" should redirect to https://api.ecobee.com/authorize?response_type=code&client_id=API_KEY&redirect_uri=https://api.cribhub.org/ecobee/register&scope=smartRead&state=CRIBHUB_ACCT_ID
