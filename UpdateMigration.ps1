# Run example: .\UpdateMigration.ps1 "MigrationName"
Write-Host "Update migration for PostgreSQL providers for the AIS SC2"

if  ($args[0] -eq $null)
{
    throw "Error | Set migration name as first parameter"
}
else
{
    $MigrationName = $args[0]
}

dotnet ef database update $MigrationName --project=Persistence --startup-project=WebApplication1 --context=ApplicationDbContext
pause
