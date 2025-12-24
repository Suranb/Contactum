

1. Make sure your appsettings has correct connection string to the postgres database.
2. Keep dotnet tool updated: dotnet tool install --global dotnet-ef



db.Database.Migrate();


*To Migrate*:
dotnet ef migrations add migrationmessage  \
  --project src/Contactum.Infrastructure \
  --startup-project src/Contactum.API \
  
dotnet ef database update \
  --project src/Contactum.Infrastructure \
  --startup-project src/Contactum.API