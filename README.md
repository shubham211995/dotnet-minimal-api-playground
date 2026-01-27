# 📦 DotNet Minimal API Playground

**DotNet Minimal API Playground** is a learning-focused project built using **.NET 8 Minimal APIs**.  
It demonstrates how to design a clean, modular Minimal API with real-world practices such as:

- Endpoint separation (no bloated `Program.cs`)
- Global exception handling
- SQLite persistence
- Swagger/OpenAPI integration
- Structured logging with Serilog
- Integration testing using `WebApplicationFactory`
- Dockerized execution

This repository is intentionally kept **simple but production-oriented**, making it suitable for:
- Learning Minimal APIs correctly
- Reference architecture for small services

---

## 🛠 Tech Stack

| Category | Technology |
|--------|------------|
| Language | C# |
| Runtime | .NET 8 |
| API Style | Minimal API |
| ORM | Entity Framework Core 8 |
| Database | SQLite |
| Logging | Serilog |
| API Docs | Swagger / OpenAPI (Swashbuckle) |
| Testing | xUnit, FluentAssertions |
| Test Type | Integration Tests |
| Containerization | Docker |
| Version Control | Git |

---

## 📁 Project Structure

```text
dotnet-minimal-api-playground
│
├── DotNet.MinimalApi.Playground.Api
│   ├── Data
│   │   └── AppDbContext.cs
│   │
│   ├── Endpoints
│   │   ├── HealthEndpoints.cs
│   │   └── UsersEndpoints.cs
│   │
│   ├── Middleware
│   │   └── GlobalExceptionMiddleware.cs
│   │
│   ├── Models
│   │   ├── User.cs
│   │   └── CreateUserRequest.cs
│   │
│   ├── Program.cs
│   └── DotNet.MinimalApi.Playground.Api.csproj
│
├── DotNet.MinimalApi.Playground.Tests
│   ├── Infrastructure
│   │   └── ApiFactory.cs
│   │
│   ├── UsersEndpointsTests.cs
│   └── DotNet.MinimalApi.Playground.Tests.csproj
│
├── Dockerfile
├── README.md
└── DotNet.MinimalApi.Playground.sln

---

## 🚀 Running the Application (Without Docker)

### Prerequisites
- .NET SDK 8.0+
- SQLite (no separate install needed, file-based)

### Steps
```bash
git clone https://github.com/<your-username>/dotnet-minimal-api-playground.git
cd dotnet-minimal-api-playground
dotnet restore
dotnet build
dotnet run --project DotNet.MinimalApi.Playground.Api

Access

Health Check: https://localhost:5001/health
Users API: https://localhost:5001/api/users
Swagger UI: https://localhost:5001/swagger
Swagger is enabled only in Development environment.