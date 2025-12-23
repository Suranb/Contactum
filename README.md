

*To Migrate*:
dotnet ef migrations add migrationchanges \
  --project src/Contactum.Infrastructure \
  --startup-project src/Contactum.API \
  
dotnet ef database update \
  --project src/Contactum.Infrastructure \
  --startup-project src/Contactum.API