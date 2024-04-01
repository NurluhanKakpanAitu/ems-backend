# Run example: .\RemoveMigration.ps1
Write-Host "Remove migration for PostgreSQL providers for the AIS SC2"
dotnet ef migrations remove --project=Persistence --startup-project=WebApplication1 --context=ApplicationDbContext
pause
