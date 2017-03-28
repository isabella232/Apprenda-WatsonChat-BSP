# Apprenda Watson Chat BSP
The Apprenda Watson Chat BSP (Bootstrap Policy) injects a chat client your website, allowing for users to interact with your Watson Conversation API (ie. a virtual agent, customer service, etc..)

### Release Notes

#### v1.0
  * Initial Release
  * Injects a Watson Chat Client into your Apprenda hosted website

## Installation
1. Clone the repository.
2. Build your bootstrapper.
3. Package your BSP by simply zipping up your compiled assemblies. 
4. Upload to your System Operations Center (SOC) -> http://docs.apprenda.com/current/bootstrap-policies 

## What You'll See

![](/readme_images/watsonchat.png)

## How to use

1. Edit your webpage (html/cshtml/aspx supported) file to include the following tag. Inside the tag, add the Application Alias of your [Watson Conversation Integration](https://github.com/apprenda/Apprenda-WatsonConversation-Integration)
![](/readme_images/watsonchatidentifier.png)

2. Build your application and bundle an archive.zip using either the Apprenda Archive Builder or the [Visual Studio Extension](http://docs.apprenda.com/downloads)

3. Create an Application within Apprenda and promote to the "Definition" stage

4. Enable the Custom Property 
	* Go to the "Configure" tab and select "components". 
	* Select application tier "Web Sites" and then click "Deployment"
	* Under the Custom Properties, click "Show Unused/Unrequired Properties"
	* Select "Watson Chat" and change the value to "Yes".
	* Click "Save".
![](/readme_images/custom_property.png)

5. Promote your application to Sandbox or Published (triggering the bootstrap policy)

![End Result](/readme_images/watsonchat_full.png)


