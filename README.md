# CafeShop POS

Windows **WinForms** Point‑of‑Sale for cafés.  
Data lives in **PostgreSQL** (via **Npgsql**). UI uses **MaterialSkin** and **LiveChartsCore (SkiaSharp)**.

---

## ✨ Features (short)
- Product & stock management  
- Sales entry and printable receipts  
- Basic reports (dashboard, sales summary)  
- PostgreSQL‑backed multi‑user data

---

## ✅ Prerequisites

- **Windows 10/11 x64**
- **Git**
- **.NET SDK** that matches the project TargetFramework (install **.NET 8 SDK** if unsure)
- (Optional) **Visual Studio 2022** with **“.NET desktop development”** workload
- Access to a shared **PostgreSQL** server

> NuGet packages (e.g., `Npgsql`, `MaterialSkin.2`, `LiveChartsCore.SkiaSharpView.WinForms`) are **auto‑restored** by `dotnet restore`.  
> No manual driver installs are needed.

---

## 🚀 Clone & Restore

```bash
git clone https://github.com/houmenghor/cafe.shop.pos
cd CafeShopManagement
dotnet restore
dotnet build
```

> If you're using Visual Studio, simply **Open the solution (.sln)** and hit **Build**.

---

## 🗃️ Database (PostgreSQL) Setup

### 1) Install PostgreSQL
- Download & install PostgreSQL (includes **pgAdmin**).  
- Remember your **port** (default `5432`) and **superuser** (`postgres`) password.

### 2) Create Database & App User

Open **psql** or **pgAdmin** and run:

```sql
-- Create DB

```sql
BEGIN;

DROP TABLE IF EXISTS sale_items, sales, stock_entries, products, users CASCADE;

CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  username VARCHAR(50) UNIQUE NOT NULL,
  password VARCHAR(255) NOT NULL,
  date_reg TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE products (
  id SERIAL PRIMARY KEY,
  name VARCHAR(100) UNIQUE NOT NULL,
  price NUMERIC(10,2) NOT NULL,
  stock INT DEFAULT 0,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE stock_entries (
  id SERIAL PRIMARY KEY,
  product_id INT NOT NULL REFERENCES products(id),
  quantity INT NOT NULL,
  entry_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE sales (
  id SERIAL PRIMARY KEY,
  sale_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  total NUMERIC(10,2) NOT NULL,
  discount NUMERIC(5,2) NOT NULL DEFAULT 0,
  grand_total NUMERIC(10,2) NOT NULL DEFAULT 0
);

CREATE TABLE sale_items (
  id SERIAL PRIMARY KEY,
  sale_id INT NOT NULL REFERENCES sales(id),
  product_id INT NOT NULL REFERENCES products(id),
  quantity INT NOT NULL,
  subtotal NUMERIC(10,2) NOT NULL
);

COMMIT;

```

---

## 🔌 Connection Tutorial (Npgsql)



1) open file `Connection.cs` class and past your Database Connection:

```csharp
using Npgsql;
namespace CafeShopManagement.Data
{
    internal class Connection
    {
        private const string ConnectionString =
           "Host=yourDBHost;Port=yourDBPort;Database=db-name;Username=yourDBUsername;Password=yourDBPassword;";

        public static NpgsqlConnection Open()
        {
            var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}

```
