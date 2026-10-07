# Visitor Management System

## Overview
ASP.NET Core API for visitor records, scheduled visits, badge-controlled entry, checkout, and reception reporting.

## Features
- JWT authentication with Admin, Reception, and Security roles
- Visitor registration with unique emails
- Scheduled visits with generated references and duplicate-day protection
- Transactional check-in/out, active badge uniqueness, search, filters, pagination, dashboard

## Technology Stack
.NET 10, ASP.NET Core, EF Core 10, SQLite, JWT, xUnit, Docker.

## Requirements / Installation / Running
Install .NET SDK 10. Run `dotnet restore Visitors.slnx` and `dotnet run --project src/Visitors.Api`. SQLite is created automatically; `migrations/001_initial.sql` documents the schema. Docker: `docker build -t visitors-api .` then `docker run -p 8080:8080 visitors-api`.

## Environment Variables
Use `.env.example`; replace `Jwt__Secret` and configure the connection string and URL for your environment.

## Running Tests
Run `dotnet test Visitors.slnx` and `dotnet list Visitors.slnx package --vulnerable --include-transitive`.

## Default Development Accounts
`admin`, `reception`, and `security`, password `ChangeMe123!` (development only).

## API Endpoints
`POST /api/auth/login`; `GET/POST /api/visitors`; `GET/POST /api/visits`; `PATCH /api/visits/{id}/check-in`; `PATCH /api/visits/{id}/check-out`; `GET /api/dashboard`.

## Folder Structure
`Models` contains entities, `Data` configures EF constraints, `Services` owns transactional entry workflows, `tests` verifies visit rules, and `migrations` documents the initial schema.

## Security Notes
Passwords are hashed, JWTs expire, roles are server enforced, EF parameterizes queries, pagination is capped, and check-in/out operations are transactional. Badge and reference uniqueness are database-backed. Use HTTPS, production secrets, restricted CORS, and an appropriate privacy/retention policy in deployment.

## Known Limitations
SQLite is for local demonstration. Photo/ID uploads, host notifications, watchlist integrations, kiosk hardware, and refresh-token revocation are intentionally excluded.

## License
MIT
