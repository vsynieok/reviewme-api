# About
API backend server for the ReviewMe application.

* The API's engine is ASP.NET Core 3.1
* Entity Framework is used for data manipulation, configured for an MS SQL database.
* Unit tests are written using NUnit and Moq
* Swagger is used in development mode for API definition reference

# Building and running
Before running, make sure a connection string is set up in the environment variable 'ConnectionStrings__Default'.

```
dotnet restore
&&
dotnet publish -c Release -o published
&&
dotnet published/ReviewMe.API.dll
```
Alternatively, the Dockerfile could be used.
