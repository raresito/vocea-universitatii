In order to add a new migration to the project use:

`cd \VoceaUniversitatiiDataModels`
`dotnet ef migrations add <Migration Name> --project ..\VoceaUniversitatiiMigrations`

In order to update database to latest migrations use:

`cd \vocea-universitaii`
`dotnet ef database update`