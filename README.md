# Loads Instagram Data From Auth0 Users
_Uses the Auth0 mangement API and Facebook Graph API to collect data from users_
## Configure
* Kestrel running behind IIS ( reverse proxy )
* .NET Core 3.1 Runtime
* Create config.json
  * Auth0: ( Auth0 app settings )
    * Domain: ( absolute path to Auth0 domain )
    * ManagementDomain: ( absolute uri to Auth0 domain with management api )
    * Id: ( Auth0 OAuth app id )
    * Secret: ( Auth0 OAuth app secret )
   * SimpleAuthKey: ( api key )
* Change launchsettings.json to change enviroment state ( PROD / DEVELOP )
