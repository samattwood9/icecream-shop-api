![Icecream Shop API](icecream-shop-api.png)

# Icecream Shop API

Code for an Icecream Shop's REST API, containing some example vulnerabilities for educational purposes.

## Getting started

You don't necessarily need to clone or download the code to get started. **You can simply click through the files and start finding vulnerabilities**.

### Running the Icecream Shop's REST API

If you're working on an activity that requires you to run the code, clone this repository, open it up in Visual Studio Code, and use the built-in terminal to complete the following steps:

#### Step 1

```c#
dotnet restore
```

#### Step 2

If you don't have the EF core tools, run:

```c#
dotnet new tool-manifest
```

```c#
dotnet tool install dotnet-ef
```

Then (or straightaway if you already have the tools), run:

**Note:** You may need to close and then re-open Visual Studio Code before running the next command.

```c#
dotnet ef database update
```

#### Step 3

```c#
dotnet run
```

#### Step 4

Navigate to http://localhost:5001 to view the Swagger (interactive documentation for the API).

Use the Seed endpoint to seed the database and then experiment with the different endpoints.
