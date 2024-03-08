![Icecream Shop API](icecream-shop-api.png)

# Icecream Shop API

Code for an Icecream Shop's REST API, containing some example vulnerabilities for educational purposes.

## Getting started

Follow steps 1-3 to get started.

#### Step 1

```c#
dotnet restore
```

#### Step 2

If you don't have the EF core tools, run:

```c#
dotnet tool install -g dotnet-ef --version 7.0.0
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

Use the Seed endpoint to seed the database and then experiment with the different endpoints. Try to relate what is returned back to the code.

## Notes

- This should work with net7.0. If you have multiple versions installed set the version in a global.json file. See: https://learn.microsoft.com/en-us/dotnet/core/versions/selection. You can check your sdk versions with: `dotnet --list-sdks`.
- https://jasonwatmore.com/post/2022/09/05/net-6-connect-to-sqlite-database-with-entity-framework-core (might be helpful if there are issues getting the db set-up, note you might need to specify versions for the nugetpackages, E.g., `--version 7.0.0`).
