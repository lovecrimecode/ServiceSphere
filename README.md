# ServiceSphere

ServiceSphere is a modular event management platform built with ASP.NET Core (.NET 8) and Entity Framework Core. It consists of a RESTful API and a Razor Pages web application for managing events, guests, services, suppliers, and organizers.

## Projects

- **ServiceSphere.API**: ASP.NET Core Web API for backend data access and business logic.
- **ServiceSphere.Web**: ASP.NET Core Razor Pages web application for user interaction.
- **ServiceSphere.Domain**: Domain models and repository interfaces.
- **ServiceSphere.Application**: Application services.
- **ServiceSphere.Infrastructure**: EF Core context and repository implementations.

## Features

- CRUD operations for Events, Guests, Services, Suppliers, and Organizers.
- RESTful API endpoints with Swagger documentation.
- Razor Pages web interface.
- SQLite database (easy to switch to other providers).

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- (Optional) [SQLite Browser](https://sqlitebrowser.org/) for inspecting the database.

### Setup

1. **Clone the repository**
   ```sh
   git clone https://github.com/lovecrimecode/ServiceSphere cd ServiceSphere
   ```

3. **Configure Connection Strings**
- Edit `appsettings.json` in both `ServiceSphere.API` and `ServiceSphere.Web` to set your SQLite connection string:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=servicesphere.db"
  }
  ```

3. **Apply Migrations**
- Open a terminal in the solution directory and run:
  ```sh
  dotnet ef database update --project ServiceSphere.Infrastructure
  ```
- Or use Visual Studio’s Package Manager Console:
  ```
  PM> Update-Database -Project ServiceSphere.Infrastructure
  ```

4. **Run the API**
- In Visual Studio, set `ServiceSphere.API` as the startup project and run.
- The API will be available at `https://localhost:5001` (or configured port).
- Swagger UI: `https://localhost:5001/swagger`

5. **Run the Web App**
- Set `ServiceSphere.Web` as the startup project and run.
- The web interface will be available at `https://localhost:5002` (or configured port).

## Usage

- Use the web interface (`ServiceSphere.Web`) to manage events, guests, services, suppliers, and organizers.
- Use the API (`ServiceSphere.API`) for programmatic access or integration.
- API documentation is available via Swagger.

## Technologies

- ASP.NET Core (.NET 8, C# 12)
- Entity Framework Core (EF Core) with SQLite
- Razor Pages & MVC
- Swagger (OpenAPI)
- Dependency Injection

