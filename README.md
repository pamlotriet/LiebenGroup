# LiebenGroup Application

This repository contains a **full-stack application** with both a **.NET backend (Server)** and an **Angular frontend (Client)**. The application provides an order and product management system.

## 🚀 Getting Started

To run this application locally, follow these steps:

---

## **📦 Prerequisites**
Ensure you have the following installed:
- **.NET 9**
- **SQL Server**
- **Entity Framework Core**
- **Angular CLI 19+**
- **Node.js & npm**

---

## **📂 Project Structure**

📦 LiebenGroup ┣ 📂 Server # .NET Backend ┃ ┣ 📂 LiebenGroupServer.Api # API Layer ┃ ┣ 📂 LiebenGroupServer.Application # Application Logic (CQRS, DTOs, Handlers) ┃ ┣ 📂 LiebenGroupServer.DataAccess # Database Models & Repository Layer ┃ ┗ 📜 LiebenGroupServer.sln # .NET Solution ┣ 📂 Client # Angular Frontend ┃📂 LiebenGroupClient # Angular Frontend ┃


---

## **🖥️ Backend Setup (.NET Core API)**
### **Clone the Repository**
```sh
git clone https://github.com/pamlotriet/LiebenGroup.git
cd LiebenGroup/Server
```

### **Configure the Database**
- Open appsettings.json in LiebenGroupServer.Api
- Update the connection string to match your local SQL Server:
  "DbConnection": "Server=YOUR_SERVER_NAME;Database=LiebenServer;Trusted_Connection=True;TrustServerCertificate=True"

### **Apply Database Migrations**
- Make sure you're in LiebenGroupServer.DataAccess, then run:
  - Add Migration:
  -  ```sh
      dotnet ef migrations add AutoGenerateGuid --project ../LiebenGroupServer.DataAccess/LiebenGroupServer.DataAccess.csproj --startup-project ../LiebenGroupServer.Api/LiebenGroupServer.Api.csproj
      ```
  - Update Database:
  -  ```sh
     dotnet ef database update --project ../LiebenGroupServer.DataAccess/LiebenGroupServer.DataAccess.csproj --startup-project ../LiebenGroupServer.Api/LiebenGroupServer.Api.csproj
      ```
  - Remove Migration:
  -  ```sh
     dotnet ef migrations remove --project ../LiebenGroupServer.DataAccess/LiebenGroupServer.DataAccess.csproj --startup-project ../LiebenGroupServer.Api/LiebenGroupServer.Api.csproj
      ```
  -  Run the API Server
  -  ```sh
     dotnet run --project LiebenGroupServer.Api
      ```

Swagger UI will be available at:
👉 https://localhost:7277/swagger

## **Frontend Setup (Angular)**
1️⃣ Navigate to the Client Folder
``` sh
cd LiebenGroupClient
```
2️⃣ Install Dependencies
 ```sh
npm install
```
3️⃣ Run the Angular Application
 ```sh
ng serve
```

📌 Angular App will be running on:
👉 http://localhost:4200

### **⚙️ Technologies Used**
Backend: .NET Core 9, Entity Framework Core, MediatR (CQRS), SQL Server
Frontend: Angular 19+, PrimeNG UI, RxJS, TypeScript
Dev Tools: Swagger for API Documentation, Mapster for Object Mapping

