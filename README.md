# Loads Instagram Data From Auth0 Users
_Uses the Auth0 mangement API and Facebook Graph API to collect data from users_
## Configure
* Kestrel running behind IIS ( reverse proxy )
* .NET Core 3.1 Runtime
* Create appsettings.json / appsettings.Develop.json ( for non production )
  * Auth0
    * auth3
* Change launchsettings.json to change enviroment state ( PROD / DEVELOP )
