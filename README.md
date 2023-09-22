# Template - .NET 6 - No Authentication/Authorisation

This template contains a functional .NET 6 RESTful API, utilising local storage. It includes a definition of an object, Sample, as well as the Controller, DTO and business logic for the object. It also contains a Seed class, used for seeding the local storage in order to make use of the API without a dedicated database

## File Structure

The file structure for this is based on the MVC model provided by Microsoft in their default web API code, and can be broken down as follows:

- **Controllers:** Contains the controller classes for both the Sample class and the Seed class, directing API requests to the relevant business logic.
- **DTOs:** Contains the Data Transfer Object definition for the Sample class.
- **Domains:** Contains the business logic for the Sample class and the Seed class, reponding to API requests and returning relevant information.
- **Error Handling:** Custom Error Handling logic, defining two additional exceptions (InputValidationException and OutputValidationException) and the ValidationConstraint class, used for enforcing validation on incoming data.
- **Models:** Contains the Model definition for the Sample class, which defines the structure of Sample objects. The object is fairly simple, containing 5 fields. This folder also contains the Context definition for the API, inheriting from DbContext and including the Samples DbSet.
- **Properties:** Contains the launchSettings.json file, defining the application URL for the API when launched as well as other settings.
  
Outside of these folders, the key files are: Startup.cs, which includes initial configuration for the API; and api.sln, which includes a list of dependencies used in this template.
