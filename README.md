# 🛒 E-commerce API

## 📌 Overview
This project is an **E-commerce Web API** built with **ASP.NET Core** and **Entity Framework Core**.  
It follows the **Repository Pattern** and supports **Generic Repository** for handling CRUD operations.

---

## 🚀 Features
- Manage **Products**, **Brands**, and **Types**.
- Generic Repository with:
  - Add
  - Update
  - Delete
  - GetById
  - GetAll
- API Endpoints:
  - **Product Controller**
    - Get All Products `{ Id, Name, Description, PictureUrl, Price, BrandName, TypeName }`
    - Get Product By Id
  - **Brand Controller**
    - Get All Brands `{ Id, Name }`
    - Get Brand By Id
    - Get All Products By Brand Id
  - **Type Controller**
    - Get All Types `{ Id, Name }`
    - Get Type By Id
    - Get All Products By Type Id

---

## 🛠️ Tech Stack
- **ASP.NET Core 7 / 8**
- **Entity Framework Core**
- **SQL Server**
- **Repository Pattern**

---

## 📂 Project Structure

E-commerce/
│── E-commerce.sln                → Solution File
│
│── E-commerce.Api/               → API Layer (Controllers & Startup)
│   │── Controllers/              → API Controllers
│   │   │── ProductController.cs
│   │   │── BrandController.cs
│   │   │── TypeController.cs
│   │
│   │── Program.cs                → Entry Point
│   │── appsettings.json          → Configuration File
│
│── E-commerce.Domain/            → Domain Layer (Entities & Contracts)
│   │── Entities/                 → Database Entities
│   │   │── BaseEntity.cs
│   │   │── Product.cs
│   │   │── Brand.cs
│   │   │── ProductType.cs
│   │
│   │── Contracts/                → Repository Interfaces
│       │── IGenericRepository.cs
│
│── E-commerce.Infrastructure/    → Infrastructure Layer (EF Core, Repository, Migrations)
│   │── dbContext/                → EF Core DbContext
│   │   │── E_commerceContext.cs
│   │
│   │── Repository/               → Generic Repository Implementation
│   │   │── GenericRepository.cs
│   │
│   │── Migrations/               → EF Core Migrations
│   │── DataSeed/                 → Seed Data JSON Files
│   │   │── brands.json
│   │   │── types.json
│   │   │── products.json

