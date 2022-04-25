# BugByte
This is a Web API used to create the bugbyte bug and issue tracking web application for KSU SWE Capstone Spring 2022

The Api is defined by Controllers, Entities, Data Transfer Objects, and Repository patterns.

Controllers define the http requestion functions to be made for the API to to the Front end of the application with JSON Data.

Entities are the Data models that represent what our database tables use to creat the database with Entity framework

Data transfer object define object the will serve to limit what properties are neccessary to perform controller functions.

Repository Patterns provide a way of making sure that we do not repeat ourselves with code and also limit what functions are available in the controller classes.

The Database is built on a the Entity Framework Core Object realtional mapper that comes with Visual studios and ASP.Net. This allows developers to make quick databases with robust sql buidling and customizing. This serves as the foundation of the API and is used by many companies to this day.
About
No description, website, or topics provided.


To use this code:


Pull the repository and make sure you have .net 6 and Asp.net installed.

We recommend using Visual Studio 2022 becuase of the support options available 

Next you need to make sure you click the .sln file in visual studio 2022. 

You should now be ready to run the API and test and create a database using the http request methods with the built in swagger UI
