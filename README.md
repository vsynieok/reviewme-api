# About
API backend server for the ReviewMe application.

* The API's engine is ASP.NET Core 3.1
* Entity Framework is used for data manipulation.
* Unit tests are written using NUnit and Moq
* Swagger is used in development mode for API definition reference

# Building and running
```
dotnet restore
&&
dotnet publish -c Release -o published
&&
dotnet published/ReviewMe.API.dll
```
Alternatively, the Dockerfile could be used.
