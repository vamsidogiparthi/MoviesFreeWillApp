# MoviesFreeWillApp
MoviesApp created with .net core 5.0, entity framework 5.0, linq, swagger, dependency injection, automapper, fluentvalidation 
## Purpose:
The purpose of this project is to establish a simple Movie WebAPI app with the above mentioned technologies, just to establish as base project to build your skills up on new technologies. 
## Summary:
The App is divided into three main layers. All the layers are built as separate projects referenced together for access and built upon the new .NET Core 5.0. Dependency injection established using interfaces which makes all the layer loosely coupled.
1. Service/Controller Layer
2. Logic Layer 
3. Data Layer(Repository)

## Service/Controller Layer:
This project contains two main controllers to fetch Movies by different criteira and Registered users. The controllers are simple and only deals with calling the responsible logic method and send the response back. 
1. Movies Controller: Contains all the api calls related to fetching movies and adding/updating the movie rating inside the database.
   1. ** NOTE: /api/movies/getmoviesbyfilters for genres. It accepts list of genres. No partial matches are allow. Full match.
2. Users Controller: Just have methods to fetch users within the database by id or all together.

## Logic Layer:
This layer mainly deals with performing all the logical operations required to present the data in the format required with complex operations. It contains logic methods to perform operations required by the api specification. It uses dependency injection, automapper, traditional linq expressions for performing various operations. All the methods in the logic layer has their own interfaces and persistance entities. The logic layer also transforms the data back to the API or callers interms of view models.

## Data Layer(Repository):
This layer mainly deals with exchanging the data back to logic layer from the db context in the form set of DTO's. Datalayer contains the MovieApp context and related database models. Below is the Schema diagram for the movieapp context.
![Movies Project DB Design](https://user-images.githubusercontent.com/30355728/132069249-ddf3bb1e-9948-4e4d-ae4e-ef9165a3a6f2.png)

Schema files are pushed into the repository under common project. Use them create the schema and load some sample data on to the database. The app is using local db. You can use anyother sql server as well. Just change the conn string in the app settings page to your database.

### NOTE: I used the automapper and traditional mapping intentionally to show case different ways to acheive mapping. Also, traditional linq mapping is recommended for nested mapping by automapper as well.

*All the common files are saved in the common project. Such as custom validations, custom exceptions etc

### Middlewares: The app use Custom exception middleware to gather all the exceptions at one place, log (not implemented yet) & send response based on the type of error. 

## Instructions to test:
The App shipped with swagger and when you run the Web project it takes you to the swagger page which will allow you to test the api's and look at the responses. You can also use postman/fiddler to test them as well. Not authentication or authorization is required...
Make sure you restore all the dependencies and packages before running the application.
