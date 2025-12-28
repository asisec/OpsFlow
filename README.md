# OpsFlow: Enterprise Organization Management System

**OpsFlow** is a modern, high-performance desktop application designed for seamless company and organization tracking. Built with a robust N-Tier architecture, it offers a secure and scalable environment for managing enterprise-level data with a contemporary user experience.

---

## 🚀 Key Features

* **Modern UI/UX:** A sleek and intuitive interface powered by the **Guna2** framework, featuring custom animated notifications and responsive design elements.
* **Secure Authentication:** Multi-step security flow including salted SHA256 hashed password protection and automated email verification for identity validation.
* **Modular N-Tier Architecture:** Organized into distinct layers (UI, Services, Core, Data) to ensure high maintainability and easy scalability.
* **Robust Data Management:** Fully integrated with **PostgreSQL** using Entity Framework Core, optimized for complex relational data.
* **Automated CI/CD:** Integrated GitHub Actions workflow for automated building and quality assurance on every commit.
* **Secure Configuration:** Advanced credential management using environment variables (`.env`) to keep sensitive database and SMTP data safe.

---

## 🏗️ Project Structure

The project follows a strict separation of concerns to enhance code quality:

* **UI (User Interface):** Houses the Guna2-powered forms and a custom-built, thread-safe notification system.
* **Services:** Contains the business logic, security protocols, and core implementations for Email and Database services.
* **Core:** The central hub for domain models (User, Company, Role), custom exceptions, and global configurations.
* **Data:** Manages the database context, SMTP settings, and configuration for PostgreSQL integration.

---

## 🛠️ Technology Stack

| Category | Technology |
| :--- | :--- |
| **Language** | C# (Latest .NET) |
| **UI Framework** | Guna2 UI WinForms |
| **Database** | PostgreSQL |
| **ORM** | Entity Framework Core |
| **Security** | SHA256 Hashing & SMTP Verification |
| **Environment** | DotNetEnv |

---

## ⚙️ Setup & Installation

### Prerequisites
* .NET SDK (Compatible with the version in .csproj)
* PostgreSQL Database instance
* SMTP Credentials (for email verification services)

### Installation Steps

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/asisec/OpsFlow.git
   ```

2. **Configure Environment Variables:**
   * Locate the `.env.example` file in the root directory.
   * Create a new file named `.env`.
   * Fill in your PostgreSQL (`DB_HOST`, `DB_PORT`, etc.) and SMTP credentials as shown in the example.

3. **Restore & Build:**
   ```bash
   dotnet restore
   dotnet build
   ```

4. **Run the Application:**
   Execute the project through your IDE or run the generated `OpsFlow.exe` in the build directory.

---

## 🔒 Security Workflow

OpsFlow prioritizes data integrity and user security:
* **Input Validation:** Every form uses a custom validation layer to prevent faulty or malicious data entry.
* **Session Management:** Verification sessions are time-limited and handle rate-limiting for security code requests.
* **Encrypted Storage:** Passwords are never stored in plain text; they are protected using unique salts and SHA256 hashing.

---
