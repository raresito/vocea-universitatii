In order to add a new migration to the project use:

`cd \VoceaUniversitatiiDataModels`  
`dotnet ef migrations add <Migration Name> --project ../VoceaUniversitatiiMigrations --startup-project ../VoceaUniversitatii`

`cd \VoceaUniversitatiiDataModels`  
`dotnet ef database update --startup-project ../VoceaUniversitatii/`