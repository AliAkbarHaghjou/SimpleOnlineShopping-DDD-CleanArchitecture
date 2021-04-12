# SimpleOnlineShopping-DomainDrivenDesign-CleanArchitecture
This is a very simple online shopping with Domain Driven Design concept and Clean Architecture in Asp.net Core 5 MVC

## Architecture And Design Patterns Which Have Been Used :
* Domain Driven Design concept
* Clean architecture

## Technologies and Libraries Which Have Been Used :
* Asp.net Core 5 MVC
* Entity Framework Core
* SQL Server for database
* Swashbuckle (For API documentation based on Swagger and OpenAPI specification)

## How to start it : 
* First of all, You have to create a database which name is **onlineshopping**
* after being sure from creating a database, You have to run this command **dotnet ef --startup-project OnlineShopping.WebApi/OnlineShopping.WebApi.csproj migrations add InitialModel -p OnlineShopping.Persistence/OnlineShopping.Persistence.csproj** in the directory where the **OnlineShopping.sln** is located to create the initial migration.
* at last, run this command **dotnet ef --startup-project OnlineShopping.WebApi/OnlineShopping.WebApi.csproj database update** in the directory where the **OnlineShopping.sln** is located to create your tables.
* Open the project solution with visual studio and **press F5**.
