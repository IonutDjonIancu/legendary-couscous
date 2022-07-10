# WepApi
This is the API which serves the cameras dataset.
It also contains a ConsoleApp which can be started using the .exe and it will prompt for a camera name.
The web app part will serve an openAPI with the cameras list.
Known issues:
- the path to the .csv file is hardcoded :(
- no unit tests
- could add more interfaces for the used objects and a factory to newup stuff
- has open CORS so that i can make calls from the client, instead of the server

# WebClient
This is the web app that consumes the data from the WebApi.
It will take the data once you click on the Get Cameras button on the top left.
It will display the cameras as per request, 3 in first column, 5 in second column, etc.
A default map using Google will display the center of Utrecht.
Once a camera name is clicked, it will move the marker to that camera location.
