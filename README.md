# Menu Configurator

Web application for ordering and configuring your meals

### Database migrations

````
dotnet ef migrations add MigrationName --project .\src\Infraestructure\MenuConfigurator.Infraestructure.csproj --startup-project .\src\Host\MenuConfigurator.Host.csproj -v
dotnet ef database update --project .\src\Infraestructure\MenuConfigurator.Infraestructure.csproj --startup-project .\src\Host\MenuConfigurator.Host.csproj
````


