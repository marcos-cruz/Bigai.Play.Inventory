# Bigai.Play.Inventory

Microservice studies project that manages the inventory of items in a catalog. 
### Create the Second Project

* In File Explorer, click on the ```Play``` folder and create a folder called ```Bigai.Play.Inventory```

* Type the command ```cd .\Bigai.Play.Inventory\``` and press enter to change folder

* Type ```code .``` and press enter. This will open Visual Studio code in the workspace

* Right click under ```Bigai.Play.Inventory``` then ```New Folder```

* Type ```src```, which is where the source code will be

* Right click on the ```src``` folder, then ```Open in Integrated Terminal```

* Type ```dotnet new webapi -n Bigai.Play.Inventory.Service``` and press enter

### Configure Build

* Inside of ```.vscode``` folder, in the ```tasks.json``` file add a group in the build section after ```problemMatcher```:

```"problemMatcher": "$msCompile",```
```    "group": {```
```        "kind": "build",```
```        "isDefault": true```
```    }```

With this configuration, you can click ```Terminal``` and then ```Run Build Task``` and the project will be built. If you prefer, you can use the shortcut ```Ctrl + Shift + B```

### Project Run

* Right click on the ```src``` folder, then click on ```Open in Integrated Terminal```

* Type ```dotnet run``` in terminal, under the source folder of project. To stop the project type ```Ctrl + C```

### Remove Open Browser

To remove open browser when launch the application, in the ```lauch.json``` file, remove or comment section ```serverReadyAction```, like this:

```
//"serverReadyAction": {
//    "action": "openExternally",
//    "pattern": "\\bNow listening on:\\s+(https?://\\S+)"
//},
```

### Setting Ports

To avoid conflicts with other microservice that run using the ports 5000 and 5001, do like this:

* In the ```Properties``` folder, open the ```launchSettings.json```

* Change the values of ports in the section ```"applicationUrl": "https://localhost:5001;http://localhost:5000",``` from
```5000``` to ```5004``` and from ```5001``` to ```5005```, for example, 

final result ```"applicationUrl": "https://localhost:5005;http://localhost:5004"```

### Adding Bigai.Play.Common NuGet Package

* Right click under ```src\Bigai.Play.Inventory.Service```

* Type the command ```dotnet add package Bigai.Play.Common```, and press enter

* Type the command ```dotnet add package Bigai.Play.Catalog.Contracts```, and press enter


### Adding Third Party Nuget package

* Right click under ```src\Bigai.Play.Inventory.Service```

* Type the command ```dotnet add package Microsoft.Extensions.Http.Polly```, and press enter
