![Icecream Shop API](icecream-shop-api.png)

# Icecream Shop API

Code for an Icecream Shop's REST API, containing some example vulnerabilities.

## Getting started

Follow steps 1-3 to get started.

#### Step 1

```c#
dotnet restore
```

#### Step 2

If you don't have the EF core tools, run:

```c#
dotnet tool install -g dotnet-ef
```

Then (or straightaway if you already have the tools), run:

```c#
dotnet ef database update
```

#### Step 3

```c#
dotnet run
```

## Notes

- This should work with net7.0. If you have multiple versions installed set the version in a global.json file. See: https://learn.microsoft.com/en-us/dotnet/core/versions/selection. You can check your sdk versions with: `dotnet --list-sdks`.
- https://jasonwatmore.com/post/2022/09/05/net-6-connect-to-sqlite-database-with-entity-framework-core (might be helpful if there are issues getting the db set-up, note you might need to specify versions for the nugetpackages, E.g., `--version 7.0.0`).
