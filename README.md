# DevOps ⚙️
## Manually Triggered 🤓
* Deploy latest commit of trunk
* Close server ( be careful as this is also GitHub event triggered )
* Open server ( be careful as this is also GitHub event triggered )
## GitHub Event Triggered 🤖
* Build and test latest push
* Deploy latest push
* to skip deploy put [ nodeploy ] in the commit message
    * example: "this is my commit message [ nodeploy ]"
* Open server at 7am
* Close server at 11pm
# Run Locally 💻
## Steps 🕹️
  * Refer to appsettings.Example.json in API project directory
  * Go to API project directory and run command 'dotnet run'
