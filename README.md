# Task Manager API

This is a secure, scalable ASP.NET Core Web API built using Clean Architecture principles.
It provides authentication, project management, and task tracking with role-based access control,

# Tech Stack

.NET 8

ASP.NET Core Web API

Entity Framework Core

PostgreSQL

JWT Authentication

FluentValidation

AutoMapper

Swagger (OpenAPI)

BCrypt (password hashing)

# Architecture 
This project follows clean architecture for maintainability and testability 

TaskManager.Api
TaskManager.Application
TaskManager.Domain
TaskManager.Infrastructure


# Layer Responsibilities

Domain

	- Core entities and enums

	- Business rules

Application

	- DTOs

	- Interfaces

	- Validation logic

Infrastructure

	- Database access (EF Core)

	- Authentication & security

	- Service implementations

API

	- Controllers

	- Middleware

	- Dependency injection

	- Swagger configuration

# Features
Authentication & Security

	- User registration and login

	- Password hashing using BCrypt

	- JWT-based authentication

	- Role-based authorization

	- Secure protected endpoints

Project Management

	- Create projects

	- Retrieve user-owned projects

	- Authorization enforced at API level

Task Management

	- Create and update tasks

	- Assign tasks to users

	- Task status tracking (Todo, InProgress, Done)

	- Pagination and filtering by status

Quality & Reliability

	- Global exception handling middleware

	- Request validation using FluentValidation

	- Clean and consistent API responses


# API Endpoints

Authentication

	- POST /api/auth/register
	- POST /api/auth/login

Projects

	- POST /api/projects
	- GET  /api/projects

Tasks

	- POST /api/tasks
	- GET  /api/tasks?projectId={id}&page=1&pageSize=10&status=Todo
	- PUT  /api/tasks/{id}

# Getting Started
Prerequisites

.NET 8 SDK

PostgreSQL

Git


# Setup 
Clone the repository
git clone https://github.com/nuel-clet/TaskManager.git

Configure database connection in appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=taskmanager_db;Username=postgres;Password=yourpassword"
}

Run migrations
set taskmanager.api as the startup project 
Add-Migrations "initial_migration"
Update-Database

Run the project
dotnet run --project TaskManager.Api
Access Swagger UI at http://localhost:5000/swagger
