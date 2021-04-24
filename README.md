# Loads Instagram Data From Auth0 Users
_Uses the Auth0 mangement API and Facebook Graph API to collect data from users_
## DevOps
* Triggering DevOps target manually
  * run workflow 'Manual DevOps Target' and enter one of the following targets:
    * deploy
      * deploys the application to the beanstalk, depending on what branch you've checked out it tags the application version with -Dev or -Prod
    * close
      * terminates the beanstalk
    * open
      * rebuilds the beanstalk, restarts it if its already up, starts it if its not up
* Build and test
  * occurs when you push to the develop or master branch or upon a pull request
* Deploy
  * occurs on push to the master or develop branches
  * to skip deploy put [ nodeploy ] in the commit message
    * example: "this is my commit message [ nodeploy ]"
## Configure development locally
* Create appsettings.json
  * Auth0: ( Auth0 app settings )
    * Domain: ( absolute path to Auth0 domain )
    * ManagementDomain: ( absolute uri to Auth0 domain with management api )
    * Id: ( Auth0 OAuth app id )
    * Secret: ( Auth0 OAuth app secret )
   * SimpleAuthKey: ( api key )
 * dotnet run inside of API directory
   * runs kestrel web server on port [ http:5000 ] and [ https:5001 ]
