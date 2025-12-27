

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


***************
# Remove old migrations (if you haven't pushed to production)
dotnet ef migrations remove --project Contactum.Infrastructure --startup-project Contactum.API

# Create new migration
dotnet ef migrations add AddPersonAndRenameCompanyTable --project Contactum.Infrastructure --startup-project Contactum.API

# Review the migration file before applying!

# Apply migration
dotnet ef database update --project src/Contactum.Infrastructure --startup-project src/Contactum.API










***--***

# 1. Drop the database
dotnet ef database drop --project src/Contactum.Infrastructure --startup-project src/Contactum.API --force

# 2. Remove ALL migrations
rm -rf src/Contactum.Infrastructure/Migrations/*

# OR on Windows:
# Remove-Item -Path Contactum.Infrastructure/Migrations/* -Recurse -Force

# 3. Create a fresh migration
dotnet ef migrations add InitialCreate --project src/Contactum.Infrastructure --startup-project src/Contactum.API

# 4. Apply it
dotnet ef database update --project src/Contactum.Infrastructure --startup-project src/Contactum.API
# 5. Check for updates
dotnet ef migrations add CheckForChanges --project src/Contactum.Infrastructure --startup-project src/Contactum.API

dotnet ef migrations remove --project src/Contactum.Infrastructure --startup-project src/Contactum.API