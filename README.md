# CafeShop POS

Windows **WinForms** Point-of-Sale for cafés.  
Data lives in **PostgreSQL** (via **Npgsql**). UI uses **MaterialSkin** and **LiveChartsCore (SkiaSharp)**.

---

## ✨ Features (short)
- Product & stock management
- Sales entry and printable receipts
- Basic reports (dashboard, sales summary)
- PostgreSQL-backed multi-user data

---

## ✅ Prerequisites

- **Windows 10/11 x64**
- **Git**
- **.NET SDK** that matches the project TargetFramework (install **.NET 8 SDK** if unsure)
- (Optional) **Visual Studio 2022** with **“.NET desktop development”** workload
- Access to a shared **PostgreSQL** server

> NuGet packages (e.g., `Npgsql`, `MaterialSkin.2`, `LiveChartsCore.SkiaSharpView.WinForms`) are **auto-restored** by `dotnet restore`.  
> No manual driver installs are needed.

---

## 🚀 Clone & Restore

```bash
git clone https://github.com/<your-org>/<your-repo>.git
cd <your-repo>
dotnet restore
dotnet build
