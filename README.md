# Learning Management System (LMS) Project

This repository contains two projects:

1. **LMS.Client**: The frontend of the application, built using Angular.
2. **LMS.WebAPI**: The backend of the application, built using .NET Core Web API.

Together, these two projects form a complete Learning Management System for managing courses, users, and other LMS functionalities.

---

## Table of Contents

- [Overview](#overview)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [LMS.Client (Frontend)](#lmsclient-frontend)
  - [Prerequisites](#lmsclient-prerequisites)
  - [Installation](#lmsclient-installation)
  - [Running the Application](#lmsclient-running-the-application)
  - [Configuration](#lmsclient-configuration)
- [LMS.WebAPI (Backend)](#lmswebapi-backend)
  - [Prerequisites](#lmswebapi-prerequisites)
  - [Configure DB Connection](#lmswebapi-configure-db-connection)
  - [Installation](#lmswebapi-installation)
  - [Running the Application](#lmswebapi-running-the-application)
  
---

## Overview

The **Learning Management System (LMS)** is a web-based solution for managing courses, users, and educational content. It allows administrators to manage course content, users to enroll in courses, and instructors to deliver content and manage the learning experience.

This repository includes both the frontend and backend implementations:

- **Frontend**: The user interface is built using Angular and consumes the backend APIs.
- **Backend**: The backend is implemented as a RESTful Web API using .NET Core, which serves as the data provider for the frontend.

---

## Technologies Used

- **Frontend**: Angular, Angular Material, RxJS, Tailwind CSS
- **Backend**: .NET Core 8, ASP.NET Core Web API, Entity Framework Core, AutoMapper, Swagger UI
- **Database**: SQL Server 
- **Authentication**: JWT-based authentication
- **Data Generation** : Data Generation: Bogus for .NET

---

## Features

This project replicates the functionality of a local library system with the following features:

1. **User Management**
   - Users can sign up, log in, and log out.
   - During sign-up, users can specify their role as either a Librarian or a Customer.

2. **Book Management (Librarian)**
   - Librarians can add new books to the library, edit existing book details, and remove books (future enhancement).
   - Librarians can mark books as returned after they have been checked out.

3. **Book Checkout (Customer)**
   - Customers can browse all available books in the library.
   - Customers can check out books. Only one copy of each book is available.
   - The system automatically tracks the availability of books.
   - Customers can leave reviews for books with a 1-5 star rating.

4. **Search and View Books**
   - Customers can search for books by a partial title match.
   - Customers can view detailed information about a book, including Title, Author, Description, Cover Image, Publisher, Publication Date, Category, ISBN, and Page Count.

---

## LMS.Client (Frontend)

This is the Angular-based frontend for the Learning Management System.

### LMS Client Prerequisites

Before running the LMS.Client project, ensure that you have the following installed:

- [Node.js](https://nodejs.org/) (version 20.x or later is recommended)
- [Angular CLI](https://angular.io/cli) (version 18.x or later)

To install Angular CLI globally:

```bash
npm install -g @angular/cli
```

### LMS Client Installation

Clone the repository and navigate to the LMS.Client directory:

```bash
git clone https://github.com/ayam-pant01/LibraryManagementSystem.git
cd LMS.Client
```

Install the required dependencies:

```bash
npm install
```

### LMS Client Running the Application

To run the Angular development server locally:

```bash
npm start
```

This will start the Angular development server, and the application can be accessed at:

```bash
http://localhost:4200/
```

### LMS Client Configuration

The API URL and other environment-specific settings can be configured in the src/environments/environment.ts file.

Example:

```bash
Copy code
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7049/api' // Backend API endpoint
};
```

## LMS.WebAPI (Backend)

This is the backend of the Learning Management System, built using .NET Core Web API.

### LMS Web Prerequisites

Before running the LMS.WebAPI project, ensure that you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (SQL Server Express or any other version)

### Configure DB Connection

Update the Connection String: Open the appsettings.json file and update the connection string to point to your SQL Server instance. Here is an example configuration for SQL Server Express:

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=LMS;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

- Replace localhost\\SQLEXPRESS with your SQL Server instance name.
- Ensure the Database name matches the database you want to use (you may need to create this database if it doesn’t already exist).
Verify SQL Server is Running: Make sure your SQL Server instance is running and accessible.

### LMS WebAPI Installation

Restore Dependencies
Navigate to the LMS.WebAPI directory and restore the necessary NuGet packages:

```bash
dotnet restore
```

Applying Migrations
If you are using Entity Framework Core migrations, apply them to set up the database schema:

Add Migrations: If you haven’t already added migrations, use the following command:

```bash
dotnet ef migrations add InitialCreate
```

Update the Database: Apply the migrations to the database with:

```bash
dotnet ef database update
```

### LMS WebAPI Running the Application

To run the application locally, use the following command:

```bash
dotnet run
```

This will start the development server. By default, it will be accessible at https://localhost:7049/. You can change the port by modifying the launchSettings.json file located in the Properties directory of your project.

Seeding Data: Data seeding is being handeled using Bogus. Application’s startup logic includes data seeding. It seeds data if the table is empty.