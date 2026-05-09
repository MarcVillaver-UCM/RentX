# RideRental - WinForms Application
## Vehicle Rental System | C# .NET Framework 4.7.2

---

## 📁 Project Structure

```
RideRental/
├── Program.cs                    ← Entry point
├── AppTheme.cs                   ← Colors, fonts, constants
├── RideRental.csproj             ← Visual Studio project file
├── packages.config               ← NuGet (MySql.Data)
│
├── Models/
│   ├── User.cs
│   ├── Vehicle.cs
│   └── Inquiry.cs
│
├── Services/
│   ├── DBConnection.cs           ← MySQL connection string
│   ├── Session.cs                ← Logged-in user state
│   ├── UserService.cs            ← Auth + Profile CRUD
│   ├── VehicleService.cs         ← Vehicle CRUD + Search
│   └── InquiryService.cs         ← Inquiry CRUD
│
├── Forms/
│   ├── MainForm.cs / .Designer.cs        ← App shell + nav bar
│   ├── LoginForm.cs / .Designer.cs       ← Login page
│   ├── RegisterForm.cs / .Designer.cs    ← Registration page
│   ├── VehicleListPanel.cs               ← Home: vehicle grid
│   ├── VehicleDetailForm.cs              ← Vehicle details dialog
│   ├── InquiryForm.cs                    ← Send inquiry + Emergency
│   ├── InquiryListPanel.cs               ← Bookings page (DataGridView)
│   ├── ProfileForm.cs                    ← User profile + password change
│   └── AboutPanel.cs                     ← About page
│
└── database_schema.sql           ← Run this in phpMyAdmin first!
```

---

## ⚙️ Setup Instructions

### Step 1 — Install MySQL Connector/NET (NuGet)

In Visual Studio:
1. Right-click the project → **Manage NuGet Packages**
2. Browse for `MySql.Data`
3. Install version **8.0.33**

Or via Package Manager Console:
```
Install-Package MySql.Data -Version 8.0.33
```

### Step 2 — Set up the Database (XAMPP)

1. Start **XAMPP** → Start **MySQL**
2. Open **phpMyAdmin** → `http://localhost/phpmyadmin`
3. Click **Import** → choose `database_schema.sql`
4. Click **Go**

This creates:
- `riderental` database
- `users`, `vehicles`, `inquiries`, `inquiry_replies` tables
- Sample data (3 users, 6 vehicles)

### Step 3 — Configure Connection (if needed)

Edit `Services/DBConnection.cs` if your MySQL settings differ:
```csharp
private const string Server   = "localhost";
private const string Database = "riderental";
private const string User     = "root";
private const string Password = "";       // XAMPP default = no password
private const int    Port     = 3306;
```

### Step 4 — Build & Run

1. Open `RideRental.csproj` in Visual Studio
2. Build Solution (`Ctrl+Shift+B`)
3. Run (`F5`)

---

## 🔑 Sample Login Credentials

| Role     | Email                     | Password    |
|----------|---------------------------|-------------|
| Personal | john@example.com          | password123 |
| Company  | jane@example.com          | password123 |
| Admin    | admin@riderental.com      | admin123    |

---

## 🖥️ Features

### ✅ User Authentication
- Login with email + password (MD5 hash)
- Register as Personal or Company account
- Session management (`Session.CurrentUser`)
- Sign out

### ✅ User Profile
- View & edit first/last name, phone
- Read-only email display
- Change password
- Company name (for company accounts)

### ✅ Vehicle System
- Grid view of all vehicles (card layout)
- Search by name, type, or tags
- Filter by vehicle type (ComboBox dropdown)
- View full vehicle details dialog
- Owner contact information shown

### ✅ Inquiry System
- Send inquiries to vehicle owners
- Subject + message fields
- Status tracking (Pending / Replied / Closed)
- View all your sent inquiries (DataGridView)
- Color-coded status and priority

### 🚨 Catastrophe Response Transport (Special Feature)
- Emergency flag checkbox on InquiryForm
- Priority levels: **High** / **Critical**
- Visual warning before sending
- Red confirmation dialog
- Emergency rows highlighted in DataGridView
- `is_emergency` flag stored in database

---

## 🗃️ Database Schema

### `users`
| Column       | Type         | Notes              |
|--------------|--------------|--------------------|
| id           | INT PK AUTO  |                    |
| first_name   | VARCHAR(100) |                    |
| last_name    | VARCHAR(100) |                    |
| email        | VARCHAR(150) | UNIQUE             |
| phone        | VARCHAR(20)  |                    |
| password_hash| VARCHAR(255) | MD5 in demo        |
| account_type | ENUM         | personal/company   |
| company_name | VARCHAR(150) |                    |
| created_at   | DATETIME     |                    |

### `vehicles`
| Column        | Type          | Notes             |
|---------------|---------------|-------------------|
| id            | INT PK AUTO   |                   |
| owner_id      | INT FK        | → users.id        |
| name          | VARCHAR(150)  |                   |
| type          | VARCHAR(50)   | Sedan, SUV, etc.  |
| fuel_type     | VARCHAR(50)   |                   |
| transmission  | VARCHAR(50)   |                   |
| seats         | INT           |                   |
| price_per_day | DECIMAL(10,2) |                   |
| rating        | DECIMAL(3,2)  |                   |
| status        | ENUM          | available/rented  |
| tags          | VARCHAR(255)  | Comma-separated   |

### `inquiries`
| Column         | Type     | Notes                         |
|----------------|----------|-------------------------------|
| id             | INT PK   |                               |
| sender_id      | INT FK   | → users.id                    |
| vehicle_id     | INT FK   | → vehicles.id                 |
| owner_id       | INT FK   | → users.id                    |
| subject        | VARCHAR  |                               |
| message        | TEXT     |                               |
| status         | ENUM     | pending/replied/closed        |
| is_emergency   | TINYINT  | **Catastrophe Response flag** |
| priority_level | ENUM     | normal/high/critical          |

---

## 🎨 UI Theme

Based on Figma mockup dark theme:
- Background: `#1A1A1A`
- Cards: `#262626`  
- Accent (Teal): `#20C997`
- Text: `#FFFFFF` / `#A0A0A0`
- Danger: `#DC3545`

All theme constants are in `AppTheme.cs`.

---

## 📝 Notes

- Forms with `Designer.cs` files can be opened in **Visual Studio Designer** via double-click
- `VehicleListPanel`, `InquiryListPanel`, `AboutPanel` are `Panel` subclasses (loaded dynamically into `MainForm`)
- `VehicleDetailForm` and `InquiryForm` are dialog `Form` instances (use `ShowDialog`)
- SQL injection is prevented via **parameterized queries** throughout all services
- All DB calls wrapped in `try/catch` with user-friendly error messages
