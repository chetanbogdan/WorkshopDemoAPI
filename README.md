# Workshop Demo API

This is a simple example of an Web API using .NET 8, Entity Framework and Fluent Validations


## Getting Started

### Dependencies

- .NET 8
- Docker
- Visual Studio/VS Code/Rider
- pgAdmin

### Adding migrations
```
dotnet ef migrations add Initial -o Data/Migrations/
```

### Applying migrations to the database
```
dotnet ef database update
```

### Deleting the last migration
```
dotnet ef migrations remove
```