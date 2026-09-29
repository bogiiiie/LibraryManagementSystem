# 📚 Library Management System

**Language:** C# (.NET Framework 4.7.2) · **UI:** Windows Forms · **Database:** SQLite

A Windows Forms application that manages a small library catalog. It demonstrates the full **CRUD + Search** lifecycle across a properly separated 4-project solution: **Model → BusinessLogic → DB → UI**.

---

## ✨ Features

- **Create** — Add a new book to the catalog
- **Read** — View all books in a `DataGridView`
- **Update** — Edit an existing book's details
- **Delete** — Remove a book (blocked if currently borrowed)
- **Search** — Find books by title, author, or ISBN

Data is persisted in a local SQLite file (`LibraryDB.db`), auto-created on first run and seeded with **5 sample books**.

---

## 🗂️ Solution Structure

```
LibrarySolution/                          (4 projects)
│
├── Model/                                Class Library
│   └── Book.cs
│
├── BusinessLogic/                        Class Library
│   ├── Controller/
│   │   └── BookController.cs
│   └── Repository/
│       ├── BookRepository.cs
│       └── DatabaseInitializer.cs
│
├── DB/                                   Class Library (scripts only)
│   ├── Table/
│   │   └── Books.sql
│   ├── PostScript/
│   │   └── SeedBooks.sql
│   ├── View/                             (empty for now)
│   └── StoredProc/                       (empty — SQLite has no stored procs)
│
└── UI/                                   Windows Forms Application
    ├── BookForm.cs
    ├── BookForm.Designer.cs
    ├── BookForm.resx
    ├── Program.cs
    ├── App.config
    ├── packages.config
    └── App_Data/                         (auto-created at runtime)
        └── LibraryDB.db
```

---

## 📁 Purpose of Each Folder

| Folder | Purpose |
|--------|---------|
| `Model/` | Holds plain data classes ("blueprints") that describe the entities of the system. Contains no logic — just properties. |
| `BusinessLogic/` | Contains the application logic — the "brain" of the app. |
| `BusinessLogic/Controller/` | Contains controllers that validate input and coordinate between UI and Repository. |
| `BusinessLogic/Repository/` | Contains repositories that talk directly to the database. Also holds `DatabaseInitializer.cs`. |
| `DB/` | Documentation-only project holding SQL scripts. No compiled code. |
| `DB/Table/` | Contains `CREATE TABLE` scripts documenting the schema. |
| `DB/PostScript/` | Contains seed scripts (`INSERT INTO ...`) that populate tables. |
| `DB/View/` | Reserved for SQL view definitions (currently empty). |
| `DB/StoredProc/` | Reserved for stored procedure scripts (empty — SQLite doesn't support them). |
| `UI/` | The Windows Forms application — the visible interface users interact with. |
| `UI/App_Data/` | Created automatically at runtime. Stores the SQLite database file. |

---

## 🏛️ Architecture Overview

```
┌──────────────────────────────────────────────┐
│                    UI                        │
│           Windows Forms Application          │
│   (BookForm, Program.cs, App.config)         │
└────────────────────┬─────────────────────────┘
                     │ calls
                     ▼
┌──────────────────────────────────────────────┐
│              BusinessLogic                   │
│                                              │
│  ┌──────────────────┐  ┌─────────────────┐  │
│  │   Controller     │─▶│   Repository    │  │
│  │ (BookController) │  │ (BookRepository,│  │
│  │  Validation      │  │  DatabaseInit.) │  │
│  └──────────────────┘  └────────┬────────┘  │
└─────────────────────────────────┼───────────┘
                                  │
                     ┌────────────┴────────────┐
                     ▼                         ▼
              ┌─────────────┐          ┌─────────────┐
              │    Model    │          │   SQLite    │
              │  (Book.cs)  │          │ LibraryDB.db│
              └─────────────┘          └─────────────┘

   ┌──────────────────────────────┐
   │         DB Project           │
   │ (SQL scripts — documentation │
   │  only; schema and seed data) │
   └──────────────────────────────┘
```

---

## 📦 Required References

| Project | Project References | Assembly References | NuGet Package |
|---------|-------------------|--------------------|-----|
| **Model** | — | defaults only | — |
| **BusinessLogic** | `Model` | `System.Configuration`, `System.Data` | `System.Data.SQLite.Core` |
| **DB** | — | — | — |
| **UI** | `BusinessLogic`, `Model` | `System.Configuration`, `System.Windows.Forms`, `System.Drawing` | `System.Data.SQLite.Core` |

---

## 📥 NuGet Packages

| Package | Version | Project(s) | Purpose |
|---------|---------|------------|---------|
| `System.Data.SQLite.Core` | 1.0.119 | `BusinessLogic`, `UI` | Provides `SQLiteConnection`, `SQLiteCommand`, `SQLiteDataReader`, plus the native `SQLite.Interop.dll` |

> ⚠️ **Do NOT install** `Microsoft.Data.Sqlite`, `System.Data.SQLite` (without "Core"), or any `SQLitePCLRaw.*` package — those target other runtimes and cause DLL loading errors on .NET Framework 4.7.2.

**Recommended platform target:** `x64` for both `BusinessLogic` and `UI`.

---

## 📄 File-by-File Reference

### `Model/Book.cs`

- **Purpose:** Blueprint for a single book record.
- **Namespace:** `Model`
- **Class:** `public class Book`

| Type | Name | Description |
|------|------|-------------|
| `int` | `BookID` | Unique ID (auto-assigned by DB) |
| `string` | `Title` | Book title |
| `string` | `Author` | Author name |
| `string` | `ISBN` | International Standard Book Number (unique) |
| `string` | `Genre` | Category |
| `int` | `YearPublished` | Year of publication |
| `bool` | `IsBorrowed` | Whether currently borrowed |

### `BusinessLogic/Repository/DatabaseInitializer.cs`

- **Purpose:** Runs once at startup. Creates the SQLite file and the `Books` table if missing, then seeds 5 sample books if the table is empty.
- **Namespace:** `BusinessLogic.Repository`
- **Class:** `public static class DatabaseInitializer`
- **Method:** `public static void EnsureDatabase()`
- **Called by:** `UI/Program.cs`

### `BusinessLogic/Repository/BookRepository.cs`

- **Purpose:** The only class that talks to SQLite. Runs SQL commands and returns `Book` objects.
- **Namespace:** `BusinessLogic.Repository`
- **Class:** `public class BookRepository`

| Method | Returns | SQL |
|--------|---------|-----|
| `GetAllBooks()` | `List<Book>` | `SELECT * FROM Books` |
| `GetBookByISBN(string)` | `Book` or `null` | `SELECT ... WHERE ISBN = @ISBN LIMIT 1` |
| `GetBookByID(int)` | `Book` or `null` | `SELECT ... WHERE BookID = @BookID LIMIT 1` |
| `AddBook(Book)` | `void` | `INSERT INTO Books ...` |
| `UpdateBook(Book)` | `void` | `UPDATE Books SET ... WHERE BookID = @BookID` |
| `DeleteBook(int)` | `void` | `DELETE FROM Books WHERE BookID = @BookID` |
| `SearchBooks(string)` | `List<Book>` | `SELECT ... WHERE Title LIKE %kw% OR Author LIKE %kw% OR ISBN LIKE %kw%` |

### `BusinessLogic/Controller/BookController.cs`

- **Purpose:** Validates input and returns `"OK"` on success or an error message.
- **Namespace:** `BusinessLogic.Controller`
- **Class:** `public class BookController`

| Method | Validation |
|--------|-----------|
| `GetAllBooks()` | passthrough |
| `GetBookByISBN(string)` | passthrough |
| `AddBook(...)` | non-empty fields, valid year, unique ISBN |
| `UpdateBook(...)` | non-empty fields, valid year |
| `DeleteBook(int)` | book must exist, must not be borrowed |
| `SearchBooks(string)` | empty keyword → return all |

### `DB/Table/Books.sql`

```sql
CREATE TABLE IF NOT EXISTS Books (
    BookID INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Author TEXT NOT NULL,
    ISBN TEXT NOT NULL UNIQUE,
    YearPublished INTEGER NOT NULL,
    Genre TEXT NOT NULL,
    IsBorrowed INTEGER NOT NULL DEFAULT 0
);
```

### `DB/PostScript/SeedBooks.sql`

`INSERT INTO Books ...` for 5 sample books. Not executed at runtime — mirrored inside `DatabaseInitializer.cs`.

### `UI/BookForm.cs`

- **Purpose:** Main user interface — DataGridView + buttons.
- **Namespace:** `UI`
- **Class:** `public partial class BookForm : Form`

| Method | Trigger | Action |
|--------|---------|--------|
| `BookForm_Load` | Form opens | Calls `LoadBooks()` |
| `LoadBooks()` | internal | `dgvBooks.DataSource = controller.GetAllBooks()` |
| `dgvBooks_SelectionChanged` | Row clicked | Fills textboxes |
| `btnAdd_Click` | Add clicked | Calls `controller.AddBook(...)` |
| `btnUpdate_Click` | Update clicked | Calls `controller.UpdateBook(...)` |
| `btnDelete_Click` | Delete clicked | Confirm → `controller.DeleteBook(...)` |
| `btnSearch_Click` | Search clicked | Calls `controller.SearchBooks(...)` |
| `btnClear_Click` | Clear clicked | Resets form |
| `btnRefresh_Click` | Refresh clicked | Calls `LoadBooks()` |

### `UI/Program.cs`

- **Purpose:** Application entry point.
- **Flow:** Enables visual styles → `DatabaseInitializer.EnsureDatabase()` → opens `BookForm`.

### `UI/App.config`

```xml
<connectionStrings>
    <add name="LibraryDB"
         connectionString="Data Source=|DataDirectory|\App_Data\LibraryDB.db;Version=3;"
         providerName="System.Data.SQLite" />
</connectionStrings>
```

---

## 🗄️ Database Schema

**Table:** `Books`

| Column | Type | Constraints | Notes |
|--------|------|-------------|-------|
| `BookID` | INTEGER | PRIMARY KEY AUTOINCREMENT | Auto-assigned ID |
| `Title` | TEXT | NOT NULL | Book title |
| `Author` | TEXT | NOT NULL | Author name |
| `ISBN` | TEXT | NOT NULL, UNIQUE | No duplicates |
| `YearPublished` | INTEGER | NOT NULL | Year of publication |
| `Genre` | TEXT | NOT NULL | Category |
| `IsBorrowed` | INTEGER | NOT NULL, DEFAULT 0 | 0 = available, 1 = borrowed |

**Location at runtime:** `UI/bin/Debug/App_Data/LibraryDB.db`

---

## 🔄 Data Flow

```
User                UI                Controller           Repository          SQLite
 │                  │                     │                    │                 │
 │  clicks Add ─────►│                     │                    │                 │
 │                  │  AddBook(...) ─────►│                    │                 │
 │                  │                     │  validate ──► error│                 │
 │                  │                     │  AddBook(Book) ───►│                 │
 │                  │                     │                    │  INSERT ──────►│
 │                  │                     │                    │◄── success ───│
 │                  │◄─── "OK" ───────────│                    │                 │
 │  sees success ◄──│                     │                    │                 │
```

---

## 🚀 How to Run

### Prerequisites
- Visual Studio with the **.NET desktop development** workload
- .NET Framework **4.7.2** (or higher)

### Steps
1. **Clone** the repository
2. **Open** `LibrarySolution.slnx` in Visual Studio
3. **Restore NuGet packages** — right-click solution → **Restore NuGet Packages**
4. **Set `UI` as Startup Project** — right-click `UI` → Set as Startup Project
5. Set **Platform target** to **x64** for `UI` and `BusinessLogic`
6. Press **`F5`** to build and run

### Optional — Inspect the database
Install **DB Browser for SQLite** from https://sqlitebrowser.org/. Open:
```
LibrarySolution/UI/bin/Debug/App_Data/LibraryDB.db
```

---

## 📋 Summary

| File | Purpose |
|------|---------|
| `Model/Book.cs` | Blueprint of a book record |
| `BusinessLogic/Repository/DatabaseInitializer.cs` | Creates DB and seeds books |
| `BusinessLogic/Repository/BookRepository.cs` | Runs SQL CRUD operations |
| `BusinessLogic/Controller/BookController.cs` | Validates input, returns result |
| `DB/Table/Books.sql` | Documents the schema |
| `DB/PostScript/SeedBooks.sql` | Documents the seed data |
| `UI/BookForm.cs` | Windows Form UI |
| `UI/Program.cs` | Entry point |
| `UI/App.config` | SQLite connection string |

---

## 📄 License

Developed for academic purposes.
```
