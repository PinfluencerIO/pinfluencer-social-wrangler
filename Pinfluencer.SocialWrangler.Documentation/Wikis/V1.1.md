# Authorization
## Usage
* in order to use the API you must pass a `Simple-Auth-Key` value in the `HTTP header`
    * this gives you access to the API
## Error Messages
* no 'Simple-Auth-Key' value was present in the request header
    * make sure the header was spelt correctly
    * make sure the value was not toggled off in the request
* 'Simple-Auth-Key' value was not valid
    * the value was either not set
    * the value did not match what was defined in the server
# Instagram Data Access
## Usage
* in order to use the API you must pass a `auth0_id` value in a `query parameter` for each request
    * this gives you access to extract Instagram data from the specified user
### Auth0 Authorization Error
# **Instagram Users**
* Url: `GET /user`
    * retrieves all Instagram users belonging to the Auth0 user passed in
    * Example Schema: `{ "insta_impressions": [ { "time": "2020-12-11T08:00:00+00:00", "count": 0 }, ... "count": 4 } ] }`
# **Instagram Insights**
* Url: `GET /user` Params: `user`
    * retrieves all Instagram users belonging to the Auth0 user passed in
    * Example Schema: `{ "insta_users": [ { "handle": "aidan_gannonnn", "id": "17841405594881885" } ], "has_multiple": false, "is_empty": false }`
