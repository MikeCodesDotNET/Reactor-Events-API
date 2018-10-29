[![Build Status](https://dev.azure.com/Advocating/Reactor%20Space%20Events/_apis/build/status/Reactor%20Space%20Events-C#%20Function-CI)](https://dev.azure.com/Advocating/Reactor%20Space%20Events/_build/latest?definitionId=2)

# Reactor Events API

An Azure Function and .NET standard library for interacting with Microsoft Reactor Events API. 

## Public API 
The API is hosted using Azure Functions and is available to you to use freely. You can find the endpoint here: 
https://reactoreventsapi.azurewebsites.net/api

An example query would look like the following: 
https://reactoreventsapi.azurewebsites.net/api/events?date=10-11-2018 


## Client SDK
The Client SDK contains the code responsible for calling the underlying API used in the web front-end. The purpose of the SDK is to simplify development and abstract the implementation details. 

You can interact with the API with the following: 

 var client = new Reactor.EventsClient.Client();
var events = await client.DownloadTodaysEvents();
