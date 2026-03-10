\# IT Asset Management API



A \*\*.NET 8 Web API\*\* built using \*\*Clean Architecture\*\* to manage company IT assets such as laptops, accessories, and device assignments to employees.



This system helps organizations track asset allocation, returns, defect reports, and inventory availability, replacing manual Excel-based asset tracking.



---



\## 🚀 Features



\* Manage company IT assets (laptops, monitors, accessories)

\* Assign assets to employees

\* Track asset return history

\* Report and manage defective devices

\* Manage accessories such as mouse, keyboard, charger

\* Maintain complete asset allocation history

\* Clean Architecture implementation

\* RESTful API design

\* Dependency Injection

\* Swagger API documentation



---



\## 🏗 Architecture



The project follows \*\*Clean Architecture\*\* principles with clear separation of concerns.



```

AssetManagement

│

├── AssetManagement.Api

├── AssetManagement.Application

├── AssetManagement.Domain

├── AssetManagement.Infrastructure

```



\### Layer Responsibilities



\*\*API Layer\*\*



\* Controllers

\* Request handling

\* Middleware

\* Swagger configuration



\*\*Application Layer\*\*



\* Business logic

\* Services

\* Interfaces

\* DTOs



\*\*Domain Layer\*\*



\* Core business entities

\* Domain models

\* Enums



\*\*Infrastructure Layer\*\*



\* Database access

\* Repository implementations

\* Entity Framework Core configuration



---



\## 🛠 Tech Stack



\* .NET 8

\* ASP.NET Core Web API

\* Entity Framework Core

\* Clean Architecture

\* Dependency Injection

\* Swagger / OpenAPI

\* SQL Server



---



\## 📦 Project Structure



```

asset-management-api

│

├── src

│   ├── AssetManagement.Api

│   ├── AssetManagement.Application

│   ├── AssetManagement.Domain

│   └── AssetManagement.Infrastructure

│

├── AssetManagement.sln

├── README.md

└── .gitignore

```



---



\## 📊 Core Entities



The system manages the following entities:



\* \*\*Employee\*\*

\* \*\*Asset\*\*

\* \*\*Accessory\*\*

\* \*\*AssetAssignment\*\*

\* \*\*DefectReport\*\*



---



\## 🔗 Example API Endpoints



\### Assets



```

POST   /api/assets

GET    /api/assets

GET    /api/assets/{id}

PUT    /api/assets/{id}

DELETE /api/assets/{id}

```



\### Asset Assignment



```

POST /api/assets/assign

POST /api/assets/return

GET  /api/assets/assignments

```



\### Accessories



```

POST /api/accessories

GET  /api/accessories

PUT  /api/accessories/{id}

```



---



\## 📈 Future Enhancements



\* JWT Authentication

\* Role-based access control

\* Asset request workflow

\* Email notifications

\* Asset usage reports

\* QR code asset tracking



---



\## 📄 License



This project is licensed under the MIT License.



