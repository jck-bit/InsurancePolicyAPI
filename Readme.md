# Insurance Policy API

This is a simple `.NET 8.0` web API for managing insurance policies.It  provides basic CRUD operations related to the policies. The API also integrates **Swagger** for automatic API documentation.

## Table of Contents
- [Live endpoints](#Enpoints)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
  - [Install Dependencies](#install-dependencies)
  - [Run Migrations](#run-migrations)
  - [Run the Application](#run-the-application)
  - [Local Endpoints And Usage](#local-endpoints-and-usage)
- [Technologies Used](#technologies-used)

If you just want to explore the deployed API, just navigate to [InsurancePoliciesApi](https://insurance-policy-api-cfcthsfqene7azbp.canadacentral-01.azurewebsites.net/swagger)


If You want to build and run it Locally, Follow the instructions below.
## Prerequisites

To run this project locally, you need the following:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet) 
- A local database (SQL Server or SQLite)
- A code editor like [Visual Studio Code](https://code.visualstudio.com/)

## Setup Instructions

Follow the steps below to set up the project locally.

### Install Dependencies

1. **Clone the repository** (or download the project files) to your local machine:

   ```bash
   git clone https://github.com/jck-bit/InsurancePolicyAPI.git
   ```

2. **Navigate to the project Folder**
    
    ```bash
     cd InsurancePolicyAPI
     ```
3. **Restore NuGet dependancies**
   ```bash
    dotnet restore
   ```

## Run Migrations

Add a new migration before updating the database

```bash
dotnet ef migrations add InitialMigration
```
then update the databse
```bash
dotnet ef database update
```
## Run the Application

```bash
dotnet run
```

The application will start and you should see it on port 5202. 

open the browser and navigate to 

``http://localhost:5202/api``

or use swagger to explore the  endpoints

`http://localhost:5202/swagger`

 ## Local Endpoints And Usage
 Once The API is up and running you can perform the following actions


| Endpoint             | Description                                                         |
| -------------------- | -------------------------------------------------------------------|
| `GET /api/`          |  Returns **Hello world**
| `GET /api/policy`    | Retrieves all policies.                                            |
| `POST /api/policy`   | Creates a new insurance policy.                                    |
| `PUT /api/policy/{id}`|Updates an existing policy by ID.                                  |
| `DELETE /api/policy/{id}`   | Deletes a policy by ID.                                     |


## Technologies Used

- **.NET 8.0**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server / SQLite**
- **Swagger / OpenAPI**
- **Docker** (optional)
