# BlazorSetupPOC
The purpose of this project is to demonstrate the initial steps to bootstrapping a Blazor application. 

*Important to note, Spaces in Blazor Project Names break so be sure to use camelCase or ke-bob.*

In the commit history you will find the steps necessary to complete various steps such as adding in render modes, streaming data, and much more.

## Duplicate project
To create a fresh barebones duplicate clone the commit *4de62a85fa890d0abab1873ee95f40f8badfc09e*. 

Then if necessary add a a database by right clicking the connected services of the non client project (BlazorDemoPOC) and then add your already created database.  This project uses a database to perform CRUD operations.   

TODO Read up on
[Blazor Sections similar to named grids](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/sections?view=aspnetcore-8.0)
[Optimize Performance](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-8.0#avoid-recreating-delegates-for-many-repeated-elements-or-components)
[Custom Validation Attributes](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-9.0#custom-validation-attributes)