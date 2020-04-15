# Monica COP.API
<!-- Short description of the project. -->

COP.API
The COP  API is intended for components delivering data and services to the  staff at the event. The main users of the API are the Common Operational Picture UI and the different apps that are part of MONICA.

![COP](https://github.com/MONICA-Project/COP.API/raw/master/COParch.png) 

The COP.API is connected to the following components in MONICA:
* IoT DB [GOST](https://github.com/gost/server) Provides the OGC Sensorthings API database
* [COP Updater](https://github.com/MONICA-Project/COPUpdater) - Is the link between the COP and the IoT Devices, pushing individual updates to the COP.
* [OGC Discovery Manager](https://github.com/MONICA-Project/COPUpdater) - Is the link between the COP and the IoT DB, forwarding newly discovered devices in the IoT DB to the COP.DB.
* EventHub provides push functionality to apps and COP-UI. This component is in fact integrated in the COP.API module but as a separate component.

The COP API is based on the following technologies:
*	MQTT interface for receiving messages for updating COP status
*	Odata-based API for retrieving resources from the IoT DB
*	Integrates SQL database with an OGC Sensorthings database for storage and management of time series of observations.

The COP API provides the following main functionalities:
*	Incident classification and management
*	Division of a geographical area into zones and subzones
*	Mapping of incidents, sensors, facilities and people/groups/crowds to zones
*	Fast retrieval of current status of the situational objects of interest


The COP API is implemented in ASP.NET Core 2.1 using Swashbuckle so it creates its own swagger definitions, that can be viewed and used for testing.

<!-- A teaser figure may be added here. It is best to keep the figure small (<500KB) and in the same repo -->

## Getting Started
The COP.API is developed in Visual Studio using Dotnet Core 2.1.

The easiest way to build it is to clone the repository using Visual Studio 2017 or higher and then build the software or to use the DotNet Core 2.1 SDK.

There are a number of ready made Docker Compose Packages demonstration environments that include the COP.API and all dependencies and provides an easy way of testing the COP.API. In addition there are a number of tutorials for the API.
### Docker Compose Packages with complete demonstration environments including the COP.API
* [Staff management package]( https://github.com/MONICA-Project/staff-management-demo)
* [Crowd management using smart wristbands and cameras](https://github.com/MONICA-Project/DockerGlobalWristbandSimulation)
* [Sound Monitoring an event using Sound Level Meters](https://github.com/MONICA-Project/DockerSoundDemo))
* [Managing weather related incidents Demo](https://github.com/MONICA-Project/DockerEnvironmentSensorDemo)
### Tutorials
* [COP API Tutorial creating POIs and Zones](https://monica-project.github.io/sections/cop-api-tutorial.html)
* [COP API Tutorial for retrieving sensordata](https://monica-project.github.io/sections/cop-api-tutorial%20sensordata.html)

## Deployment
For deployment the COP.API relies on a Postgres database for internal use as well as a connection to a GOST database. If one uses one of the demonstration docker compose environments they will automatically be created.

### Docker
#### Environment Variables that need to be set
| Variable | Description | Example | 
| --------------- | --------------- | --------------- |
| MEDIA_PATH | Shared container path used only together with smart glasses.| /ora_shared/ | 
| CONNECTION_STR | COP Database connection string | Host=copdb; Database=monica_wt2019; Username=postgres; Password=postgres;Port=5432 | 
| GOST_PREFIX | GOST | Should match the MQTT prefix useb by the GOST db |
| TEST_TOKEN | 6ffdcacb-c485-499c-bce9-23f76d06aa36 | The fixed access token |
| USE_GOSTOBS | True if the API will retrieve Observations directly  from GOST | true | 
 | GOST_SERVER | GOST Server address | http://gost:8080/v1.0/ |
| URL_PREFIX | If the API is not deployed directly under toplevel this needs to be set | TIVOLI for deployment on http://../TIVOLI|
|USE_GOSTSEARCHOBS| False uses legacy model of finding datastreams |true|



To run the latest version of COP.API:
```bash
docker run -p 8800:80 -e MEDIA_PATH=/ora_shared/ -e CONNECTION_STR=Host=copdb;Database=monica_wt2019;Username=postgres;Password=postgres;Port=5432 -e GOSTPrefix=GOST -e TEST_TOKEN=6ffdcacb-c485-499c-bce9-23f76d06aa36 -e USE_GOSTOBS=true -e GOST_SERVER=http://gost:8080/v1.0/  -e URL_PREFIX= -e USE_GOSTSEARCHOBS=true monicaproject/copapi:0.3
```
NB! The Prerequisites must exist and be started when starting the COP.API 

## Development
To start development it is enough to clone the repository and then build it either using Visual Studio or Dotnet Core SDK to build and run the API.
It is recomended to use one of the Docker Compose Packages with complete demonstration environments mentioned above to have some testing data and to have the complete COP environemnt available.

The code for the COP.API is based on ASP.NET Core framework and for COP.DB access Microsoft.EntityFrameworkCore is used.


### Prerequisite
Either one of the Docker Compose Packages with complete demonstration environments, or manually install the following components:
* GOST (IoT DB). Installation instructions are available [here](https://www.gostserver.xyz/)
* PostgreSQL. Installation instructions are available [here](https://www.postgresql.org/)
    - COP DB needs to be loaded in the database, instructions [here](https://github.com/MONICA-Project/COP.DB)
* Dotnet Core SDK 2.1 available [here](https://dotnet.microsoft.com/download/dotnet-core/2.1)
    - Or use Visual Studio 2017 or higher



### Build

```bash
dotnet build
```

### Endpoints exposed
The default port that is exposed is port 80
* API with swagger is reached on http://ip/
* SignalR is reached on http://ip/signalR/COPUpdate
## 
## Contributing
Contributions are welcome. 

Please fork, make your changes, and submit a pull request. For major changes, please open an issue first and discuss it with the other authors.

## Affiliation
![MONICA](https://github.com/MONICA-Project/template/raw/master/monica.png)  
This work is supported by the European Commission through the [MONICA H2020 PROJECT](https://www.monica-project.eu) under grant agreement No 732350.
