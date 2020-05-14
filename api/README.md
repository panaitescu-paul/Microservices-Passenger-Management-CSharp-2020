# Setup
### Default:
Run ```docker-compose up --build``` using ```docker-compose.yml``` found at ```api/docker-compose-standalone```.<br> In this setup, the API will listen for Kafka at address ```kafka:9092``` (```kafka``` being the name of the kafka container), but the API will need to be manually linked to Kafka's container using the ```--link``` flag.

### Custom:

The configuration file can be found at ```api/appsettings.json```. <br>
The new setup can be executed by ```docker-compose up --build``` using ```.../api``` as the current working directory.
