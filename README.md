# WhatsApp-Server

This solution include 2 project:
- API - Its a web service that recevice and sent HTTP request and store the data on a LocalDB.
- WebClient - this part include the React code (inserted using the build command) and the feedback page.

## API (Web Service)
The web service based on WebAPI model (.NET). It work with a localDB (ProjectModels), when a controller get a request the controller turns to the service and the last runs the query on the DB.The queries that are intended to the contact/message controller is limited.<br />The acess is permitted just for a user that have a token (Issued at login).

#### Technologies:
- JWT
- SignalR
- Entity Framework (ProjectModels)


## WebClient
The WebClient based on the MVC model and include 2 parts:
- Chat (Based on React) - it's the same code as the last exercise except for the changes made to communicate with the API. Each request is send with a token (given by the API when signin) and it recieve a signal when there is an incoming message.
- Feedback - Its the page where you can add a feedback about the website.
To reach this page the user will need to press on the feedback button from the home page of Signin page (main page).
To add a new feedback press on the button 'create new feedback button'. As mention the feedback site work in MVC platform, that include: models, services and controllers. The service use a localDB to store the data. The site support all the CRUED: create, edit, details, delete. The site also support a search function on the users who fill a feedback on the website.

#### Technologies:
- JWT
- SignalR
- React
- Bootstrap
- Entity Framework (ProjectModels)

## Run
The API (WebService) need to run on the address: https://localhost:7156/.
Also you need to set up 2 databases: API and the WebClient. To do this you have to run on the console the command: 'Update-Database'.



## Submitting

- Daniel Houri: 314712563
- Dor Huri: 209409218

