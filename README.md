# Apprenda Bootstrap Policy Sample Template
Empty Bootstrap template to help jump start your BSP development!

The following repository is meant to help and provide BSP developers with a ready to use template alongside the required Apprenda dependencies (version 6.5.1). 

Additional information about creating bootstrap policies can be found here: 
* Understanding Bootstrap Policies - http://docs.apprenda.com/current/bootstrap-policies
* Building a custom bootstrapper - http://docs.apprenda.com/current/custom-bootstrapper
* Platform Modifications, allows you to load files into a Linux based application - http://docs.apprenda.com/current/platform-mods

# How to Use?
1. Clone the repository.
2. Build your bootstrapper.
3. Package your BSP by simply zipping up your compiled assemblies. 
4. Upload to your System Operations Center (SOC) -> http://docs.apprenda.com/current/bootstrap-policies 

# Modifying the Apprenda Target Version
This BSP is packaged with the DLL for Apprenda Version 6.5.1. If you wish to use a different Apprenda version, simply replace the Apprenda.API.Extension.dll file in the lib folder with the desired version installed from your SDK. 

