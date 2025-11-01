Here’s a drop-in **README.md** for your repo.

---

# CafeShop POS

Windows **WinForms** Point-of-Sale for cafés.
Data is stored in **PostgreSQL** and accessed via **Npgsql**. The UI uses **MaterialSkin** and **LiveCharts (Core + SkiaSharp)**.

---

## Tech Stack

* .NET (WinForms) – target: `net8.0-windows` (or your project’s TargetFramework)
* PostgreSQL (central/shared server)
* NuGet packages (auto-restored):

  * `Npgsql`
  * `MaterialSkin.2`
  * `LiveChartsCore.SkiaSharpView.WinForms` *(preferred for .NET 6/7/8)*
  * *(If the repo still includes the legacy `LiveCharts` package, keep only one charts stack to avoid conflicts.)*

---

## Prerequisites

* **Windows 10/11 x64**
* **Git**
* **.NET SDK** that matches the project TargetFramework (install **.NET 8 SDK** if unsure)
* **Visual Studio 2022** with **“.NET desktop development”** workload *(optional if using the `dotnet` CLI)*
* Access to a **PostgreSQL** server

> You **don’t** install Npgsql/MaterialSkin/LiveCharts manually — `dotnet restore` / Visual Studio restores NuGet packages from the project.

---

## Clone & Run

```bash
git clone https://github.com/<your-org>/<your-repo>.git
cd <your-repo>
dotnet restore
dotnet build
```

Configure the database (choose ONE):

**A) Config file (recommended)**
Copy the sample and edit connection info:

```powershell
copy cafe_db.example.json cafe_db.json
```

`cafe_db.json`

```json
{
  "connectionString": "Host=10.0.0.5;Port=5432;Database=cafe_shop_management;Username=cafeapp;Password=STRONG_PASSWORD;Pooling=true;Timeout=5;Command Timeout=30"
}
```

**B) Environment variable**

```powershell
[System.Environment]::SetEnvironmentVariable(
  "CSM_DB",
  "Host=10.0.0.5;Port=5432;Database=cafe_shop_management;Username=cafeapp;Password=STRONG_PASSWORD;Pooling=true",
  "User"
)
```

Run the app:

* **Visual Studio**: open the solution, set `CafeShopManagement` as startup, press **F5**
* **CLI**:

```bash
dotnet run --project CafeShopManagement
```

---

## Database Setup (once, on the server)

```sql
CREATE USER cafeapp WITH PASSWORD 'STRONG_PASSWORD';
CREATE DATABASE cafe_shop_management OWNER cafeapp;
GRANT ALL PRIVILEGES ON DATABASE cafe_shop_management TO cafeapp;

-- If schema already exists
GRANT USAGE ON SCHEMA public TO cafeapp;
GRANT ALL ON ALL TABLES IN SCHEMA public TO cafeapp;
GRANT ALL ON ALL SEQUENCES IN SCHEMA public TO cafeapp;
```

Server access:

* `postgresql.conf`: `listen_addresses = '*'`
* `pg_hba.conf`: `host  all  all  192.168.1.0/24  md5` (adjust network)
* Open firewall **TCP 5432**

> WAN/Internet: consider `SSL Mode=Require;Trust Server Certificate=true` in the connection string.

---

## Configuration Rules

The app reads the connection string in this order:

1. Environment variable **`CSM_DB`**
2. **`cafe_db.json`** next to the `.exe` / project output
3. Internal fallback (dev only)

Keep secrets out of Git:

```
# .gitignore
cafe_db.json
bin/
obj/
*.user
```

Ship `cafe_db.example.json` only (no real passwords).

---

## Project Structure (short)

```
CafeShopManagement/
 ├─ Data/            # Connection + repositories
 ├─ Forms/           # WinForms UI (DashboardForm, SalesForm, etc.)
 ├─ Models/          # POCO models (Product, Receipt, ...)
 ├─ CafeShopManagement.sln
 └─ README.md
```

---

## Troubleshooting

* **Timeout / cannot connect:** firewall/port 5432, `pg_hba.conf`, or wrong host (don’t use `localhost` for remote PCs).
* **Auth failed (28P01):** wrong user/password or missing grants.
* **Charts not rendering / build conflicts:** ensure you use **either** `LiveChartsCore.*` **or** legacy `LiveCharts`, not both.
* **Missing .NET runtime:** install the SDK matching the project TargetFramework.

---

## Contributing

1. Fork → create feature branch `feat/<name>`
2. Commit with conventional prefixes (`feat:`, `fix:`, `chore:`, `docs:`)
3. Pull Request

---

## License


