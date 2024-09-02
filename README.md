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
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
  - [Build](#build)
  - [Testing](#testing)
  - [Configuration](#configuration)
- [LMS.WebAPI (Backend)](#lmswebapi-backend)
  - [Prerequisites](#prerequisites-1)
  - [Installation](#installation-1)
  - [Running the Application](#running-the-application-1)
  - [Testing](#testing-1)
- [License](#license)

---

## Overview

The **Learning Management System (LMS)** is a web-based solution for managing courses, users, and educational content. It allows administrators to manage course content, users to enroll in courses, and instructors to deliver content and manage the learning experience.

This repository includes both the frontend and backend implementations:

- **Frontend**: The user interface is built using Angular and consumes the backend APIs.
- **Backend**: The backend is implemented as a RESTful Web API using .NET Core, which serves as the data provider for the frontend.

---

## Technologies Used

- **Frontend**: Angular, Angular Material, RxJS, Tailwind CSS
- **Backend**: .NET Core Web API, Entity Framework Core
- **Database**: SQL Server (or any database supported by EF Core)
- **Authentication**: JWT-based authentication

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

5. **Bonus Features (Optional)**
   - A component library is used on the frontend to enhance UI/UX.
   - Swagger UI / OpenAPI documentation is configured for the API.
   - Unit tests for the API are implemented.
   - The database is seeded with data using Bogus for .NET.
---

## LMS.Client (Frontend)

This is the Angular-based frontend for the Learning Management System.

### Prerequisites

Before running the LMS.Client project, ensure that you have the following installed:

- [Node.js](https://nodejs.org/) (version 20.x or later is recommended)
- [Angular CLI](https://angular.io/cli) (version 18.x or later)

To install Angular CLI globally:

```bash
npm install -g @angular/cli
