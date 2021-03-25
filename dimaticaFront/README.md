# DimaticaFront

The purpose of this technical test is to create an end-to-end web application that allows
the user to read, create and update a to-do list of duties of any kind.



## Installation

I would have liked to configure the deployment through kubernetes but due to time constraints it was not possible.

The solution is composed of backend (.NET CORE) and frontend (Angular), there is the possibility of deployment through dockers building the images from the dockerfile of each solution.

For the deployment of MongoDB its docker image is used:
```bash
docker pull mongo
docker run -d  --name mongo-on-docker  -p 27017:27017  mongo
```

In This way we expose the port for our backend to use the database.

The second step is to run the backend, this can be done from Visual Studio or by running directly the executable located at: 
\dimaticaAPI\dimaticaAPI\bin\Debug\netcoreapp3.1

Finally the frontend will be executed, in this case it is possible to use: ng serve from the folder \dematicatest\dimaticaFront or generate the docker image using the Dockerfile provided.

It is important to note that the default frontend tries to connect to the API in the address: https://localhost:44382/api/duties/, if the backend is deployed in other port, this value should be updated in : dimaticaFront\src\app\services\http.service.ts, line 11:


```bash
private REST_API_SERVER = "https://localhost:44382/api/duties/";
```

