# Loads Instagram Data From Auth0 Users
_Uses the Auth0 mangement API and Facebook Graph API to collect data from users_
## DevOps
### Manually Triggered
* `deploy` [ deploys the application to the beanstalk ]
* `close` [ terminates the beanstalk ]
* `open` [ rebuilds the beanstalk ]
### GitHub Event Triggered
* `build and test` [ occurs on push or pull request ]
* `deploy` [ occurs on push ]
* to skip `deploy` put `[ nodeploy ]` in the commit message
    * example: "this is my commit message [ nodeploy ]"
## Configure development locally
### App Settings ( appsettings.json )
  * AuthService: ( Auth0 app settings )
    * Domain: ( absolute path to Auth0 domain )
    * ManagementDomain: ( absolute uri to Auth0 domain with management api )
    * Id: ( Auth0 OAuth app id )
    * Secret: ( Auth0 OAuth app secret )
  * PinfluencerData: ( Bubble app settings )
    * Domain: ( absolute path to Bubble data api )
    * Secret: ( Bubble API Token )
   * SimpleAuthKey: ( api key )
### Run
   1. `cd Pinfluencer.SocialWrangler.API`
   2. `dotnet run` [ runs kestrel on port [ http:5000 ] and [ https:5001 ] ]
