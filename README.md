# Clean Architecture API

## Configuração da ORM para PostgreSQL

### Caminho para `appsettings.json`

```shell
  Presentation
    └── CleanArchitecture.API
          └── appsettings.json
```

### Configuração do `appsettings.json`

```json
{
  "ConnectionStrings": {
    "PostgreSQL": "Server=localhost;Database=userdb;User ID=appuser;Password=12345;Port=5432;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
### Caminho para `ServiceExtensions.cs`

```shell
  Infraestructure
    └── CleanArchitecture.Persistence
          └── ServiceExtensions.cs
```

### Configuração do `ServiceExtensions.cs`

```csharp
namespace CleanArchitecture.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL");
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
```

### Endpoints da Aplicação

```plaintext
GET /api/Users
```
```plaintext
POST /api/Users
```
```plaintext
PUT /api/Users
```
```plaintext
DELETE /api/Users
```
