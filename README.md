\# 📚 Library Management System



\*\*Language:\*\* C# (.NET Framework 4.7.2) · \*\*UI:\*\* Windows Forms · \*\*Database:\*\* SQLite



A Windows Forms application that manages a small library catalog. It demonstrates the full \*\*CRUD + Search\*\* lifecycle across a properly separated 4-project solution: \*\*Model → BusinessLogic → DB → UI\*\*.



\---



\## ✨ Features



\- \*\*Create\*\* — Add a new book to the catalog

\- \*\*Read\*\* — View all books in a `DataGridView`

\- \*\*Update\*\* — Edit an existing book's details

\- \*\*Delete\*\* — Remove a book (blocked if currently borrowed)

\- \*\*Search\*\* — Find books by title, author, or ISBN



Data is persisted in a local SQLite file (`LibraryDB.db`), auto-created on first run and seeded with \*\*5 sample books\*\*.



\---



\## 🗂️ Solution Structure



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

&#x20;   ├── BookForm.cs

&#x20;   ├── BookForm.Designer.cs

&#x20;   ├── BookForm.resx

&#x20;   ├── Program.cs

&#x20;   ├── App.config

&#x20;   ├── packages.config

&#x20;   └── App\_Data/                         (auto-created at runtime)

&#x20;       └── LibraryDB.db

```



\---



\## 📁 Purpose of Each Folder



| Folder | Purpose |

|--------|---------|

| \*\*`Model/`\*\* | Holds \*\*plain data classes\*\* ("blueprints") that describe the entities of the system. Contains no logic — just properties. Example: `Book.cs`. |

| \*\*`BusinessLogic/`\*\* | Contains the \*\*application logic\*\* — the "brain" of the app. Split into two subfolders below. |

| \*\*`BusinessLogic/Controller/`\*\* | Contains \*\*controllers\*\* that validate input and coordinate between UI and Repository. Business rules live here. |

| \*\*`BusinessLogic/Repository/`\*\* | Contains \*\*repositories\*\* that talk directly to the database. Also holds `DatabaseInitializer.cs` for first-run setup. |

| \*\*`DB/`\*\* | Documentation-only project holding \*\*SQL scripts\*\*. Contains no compiled C# code — serves as a readable reference for the schema and seed data. |

| \*\*`DB/Table/`\*\* | Contains \*\*`CREATE TABLE` scripts\*\* documenting the schema of each database table. |

| \*\*`DB/PostScript/`\*\* | Contains \*\*seed scripts\*\* (`INSERT INTO ...`) that populate tables with initial data. |

| \*\*`DB/View/`\*\* | Reserved for SQL \*\*view\*\* definitions (currently empty). |

| \*\*`DB/StoredProc/`\*\* | Reserved for \*\*stored procedure\*\* scripts (empty — SQLite does not support them). |

| \*\*`UI/`\*\* | The \*\*Windows Forms application\*\* — the visible interface users interact with. Contains forms, program entry point, and configuration. |

| \*\*`UI/App\_Data/`\*\* | Created automatically at runtime. Stores the \*\*SQLite database file\*\* (`LibraryDB.db`). |



\---



\## 🏛️ Architecture Overview



```

┌──────────────────────────────────────────────┐

│                    UI                        │

│           Windows Forms Application          │

│   (BookForm, Program.cs, App.config)         │

└────────────────────┬─────────────────────────┘

&#x20;                    │ calls

&#x20;                    ▼

┌──────────────────────────────────────────────┐

│              BusinessLogic                   │

│                                              │

│  ┌──────────────────┐  ┌─────────────────┐  │

│  │   Controller     │─▶│   Repository    │  │

│  │ (BookController) │  │ (BookRepository,│  │

│  │  Validation      │  │  DatabaseInit.) │  │

│  └──────────────────┘  └────────┬────────┘  │

└─────────────────────────────────┼───────────┘

&#x20;                                 │

&#x20;                    ┌────────────┴────────────┐

&#x20;                    ▼                         ▼

&#x20;             ┌─────────────┐          ┌─────────────┐

&#x20;             │    Model    │          │   SQLite    │

&#x20;             │  (Book.cs)  │          │ LibraryDB.db│

&#x20;             └─────────────┘          └─────────────┘



&#x20;  ┌──────────────────────────────┐

&#x20;  │         DB Project           │

&#x20;  │ (SQL scripts — documentation │

&#x20;  │  only; schema and seed data) │

&#x20;  └──────────────────────────────┘

```



\---



\## 📦 Required References



| Project | Project References | Assembly References | NuGet Package |

|---------|-------------------|--------------------|-----|

| \*\*Model\*\* | — | defaults only | — |

| \*\*BusinessLogic\*\* | `Model` | `System.Configuration`, `System.Data` | `System.Data.SQLite.Core` |

| \*\*DB\*\* | — | — | — |

| \*\*UI\*\* | `BusinessLogic`, `Model` | `System.Configuration`, `System.Windows.Forms`, `System.Drawing` | `System.Data.SQLite.Core` |



\---



\## 📥 NuGet Packages



| Package | Version | Project(s) | Purpose |

|---------|---------|------------|---------|

| `System.Data.SQLite.Core` | 1.0.119 | `BusinessLogic`, `UI` | Provides `SQLiteConnection`, `SQLiteCommand`, `SQLiteDataReader`, plus the native `SQLite.Interop.dll` |



> ⚠️ \*\*Do NOT install\*\* `Microsoft.Data.Sqlite`, `System.Data.SQLite` (without "Core"), or any `SQLitePCLRaw.\*` package — those target other runtimes and cause DLL loading errors on .NET Framework 4.7.2.



\*\*Recommended platform target:\*\* `x64` for both `BusinessLogic` and `UI`.



\---



\## 📄 File-by-File Reference



\### `Model/Book.cs`

\- \*\*Purpose:\*\* Blueprint for a single book record.

\- \*\*Namespace:\*\* `Model`

\- \*\*Class:\*\* `public class Book`

\- \*\*Properties:\*\*



&#x20; | Type | Name | Description |

&#x20; |------|------|-------------|

&#x20; | `int` | `BookID` | Unique ID (auto-assigned by DB) |

&#x20; | `string` | `Title` | Book title |

&#x20; | `string` | `Author` | Author name |

&#x20; | `string` | `ISBN` | International Standard Book Number (unique) |

&#x20; | `string` | `Genre` | Category (Fantasy, Fiction, etc.) |

&#x20; | `int` | `YearPublished` | Year of publication |

&#x20; | `bool` | `IsBorrowed` | Whether currently borrowed |



\---



\### `BusinessLogic/Repository/DatabaseInitializer.cs`

\- \*\*Purpose:\*\* Runs once at startup. Creates the SQLite file and the `Books` table if they don't exist, then seeds 5 sample books if the table is empty.

\- \*\*Namespace:\*\* `BusinessLogic.Repository`

\- \*\*Class:\*\* `public static class DatabaseInitializer`

\- \*\*Method:\*\* `public static void EnsureDatabase()`

\- \*\*Flow:\*\*

&#x20; 1. Reads connection string from `App.config`.

&#x20; 2. Resolves `|DataDirectory|` to a real path.

&#x20; 3. Creates the `App\_Data` folder if missing.

&#x20; 4. Opens (or creates) `LibraryDB.db`.

&#x20; 5. Runs `CREATE TABLE IF NOT EXISTS Books (...)`.

&#x20; 6. Checks `SELECT COUNT(\*) FROM Books`. If `0`, inserts 5 seed books.

\- \*\*Called by:\*\* `UI/Program.cs` at startup.



\---



\### `BusinessLogic/Repository/BookRepository.cs`

\- \*\*Purpose:\*\* The only class that talks to the SQLite database. Runs SQL commands and returns `Book` objects.

\- \*\*Namespace:\*\* `BusinessLogic.Repository`

\- \*\*Class:\*\* `public class BookRepository`

\- \*\*Constructor:\*\* Reads the `LibraryDB` connection string from `App.config`.

\- \*\*Methods:\*\*



&#x20; | Method | Returns | SQL |

&#x20; |--------|---------|-----|

&#x20; | `GetAllBooks()` | `List<Book>` | `SELECT \* FROM Books` |

&#x20; | `GetBookByISBN(string isbn)` | `Book` or `null` | `SELECT ... WHERE ISBN = @ISBN LIMIT 1` |

&#x20; | `GetBookByID(int bookID)` | `Book` or `null` | `SELECT ... WHERE BookID = @BookID LIMIT 1` |

&#x20; | `AddBook(Book book)` | `void` | `INSERT INTO Books ...` |

&#x20; | `UpdateBook(Book book)` | `void` | `UPDATE Books SET ... WHERE BookID = @BookID` |

&#x20; | `DeleteBook(int bookID)` | `void` | `DELETE FROM Books WHERE BookID = @BookID` |

&#x20; | `SearchBooks(string keyword)` | `List<Book>` | `SELECT ... WHERE Title LIKE %kw% OR Author LIKE %kw% OR ISBN LIKE %kw%` |



\- \*\*Pattern:\*\* Every method uses `using (var conn = ...)` to auto-close the connection, and `cmd.Parameters.AddWithValue(...)` to prevent SQL injection.



\---



\### `BusinessLogic/Controller/BookController.cs`

\- \*\*Purpose:\*\* Middle layer between UI and Repository. Validates input and returns a `string` result (`"OK"` = success, anything else = error message).

\- \*\*Namespace:\*\* `BusinessLogic.Controller`

\- \*\*Class:\*\* `public class BookController`

\- \*\*Methods:\*\*



&#x20; | Method | Validation |

&#x20; |--------|-----------|

&#x20; | `GetAllBooks()` | passthrough |

&#x20; | `GetBookByISBN(string)` | passthrough |

&#x20; | `AddBook(title, author, isbn, year, genre)` | non-empty fields, year in \[1000, current], ISBN must not be duplicate |

&#x20; | `UpdateBook(bookID, title, author, year, genre, isBorrowed)` | non-empty fields, year in range |

&#x20; | `DeleteBook(bookID)` | book must exist, must not be borrowed |

&#x20; | `SearchBooks(keyword)` | empty keyword → return all |



\- \*\*Return convention:\*\* returns `"OK"` on success; returns a user-friendly error message on failure.



\---



\### `DB/Table/Books.sql`

\- \*\*Purpose:\*\* Documentation of the `Books` table schema.

\- \*\*Content:\*\*

&#x20; ```sql

&#x20; CREATE TABLE IF NOT EXISTS Books (

&#x20;     BookID INTEGER PRIMARY KEY AUTOINCREMENT,

&#x20;     Title TEXT NOT NULL,

&#x20;     Author TEXT NOT NULL,

&#x20;     ISBN TEXT NOT NULL UNIQUE,

&#x20;     YearPublished INTEGER NOT NULL,

&#x20;     Genre TEXT NOT NULL,

&#x20;     IsBorrowed INTEGER NOT NULL DEFAULT 0

&#x20; );

&#x20; ```

\- \*\*Not executed at runtime\*\* — mirrored inside `DatabaseInitializer.cs`.



\---



\### `DB/PostScript/SeedBooks.sql`

\- \*\*Purpose:\*\* Documentation of the 5 seed books.

\- \*\*Content:\*\* `INSERT INTO Books (Title, Author, ISBN, YearPublished, Genre) VALUES (...)` for \*The Hobbit\*, \*1984\*, \*To Kill a Mockingbird\*, \*The Great Gatsby\*, and \*Pride and Prejudice\*.

\- \*\*Not executed at runtime\*\* — mirrored inside `DatabaseInitializer.cs`.



\---



\### `UI/BookForm.cs`

\- \*\*Purpose:\*\* Main user interface — displays books in a `DataGridView`, provides buttons to Add / Update / Delete / Search / Clear / Refresh.

\- \*\*Namespace:\*\* `UI`

\- \*\*Class:\*\* `public partial class BookForm : Form`

\- \*\*Field:\*\* `private readonly BookController controller = new BookController();`

\- \*\*Key methods:\*\*



&#x20; | Method | Trigger | Action |

&#x20; |--------|---------|--------|

&#x20; | `BookForm\_Load` | Form opens | Calls `LoadBooks()` |

&#x20; | `LoadBooks()` | internal | `dgvBooks.DataSource = controller.GetAllBooks()` |

&#x20; | `dgvBooks\_SelectionChanged` | Row clicked | Fills textboxes with selected book |

&#x20; | `btnAdd\_Click` | Add clicked | Parses year → `controller.AddBook(...)` |

&#x20; | `btnUpdate\_Click` | Update clicked | `controller.UpdateBook(...)` |

&#x20; | `btnDelete\_Click` | Delete clicked | Confirmation → `controller.DeleteBook(...)` |

&#x20; | `btnSearch\_Click` | Search clicked | `controller.SearchBooks(txtSearch.Text)` |

&#x20; | `btnClear\_Click` | Clear clicked | Resets form + `LoadBooks()` |

&#x20; | `btnRefresh\_Click` | Refresh clicked | `LoadBooks()` |

&#x20; | `ShowResult(string)` | internal | Displays success or error, refreshes grid |



\- \*\*UI Controls used:\*\* `dgvBooks`, `txtTitle`, `txtAuthor`, `txtISBN`, `txtYear`, `txtGenre`, `chkBorrowed`, `txtSearch`, `lblCount`, and six buttons.



\---



\### `UI/Program.cs`

\- \*\*Purpose:\*\* Application entry point.

\- \*\*Namespace:\*\* `UI`

\- \*\*Class:\*\* `internal static class Program`

\- \*\*Flow:\*\*

&#x20; 1. Enables visual styles.

&#x20; 2. \*\*Calls `DatabaseInitializer.EnsureDatabase()`\*\* — creates and seeds the DB before the form opens.

&#x20; 3. Opens `BookForm`.



\---



\### `UI/App.config`

\- \*\*Purpose:\*\* Stores the SQLite connection string.

\- \*\*Content:\*\*

&#x20; ```xml

&#x20; <connectionStrings>

&#x20;     <add name="LibraryDB"

&#x20;          connectionString="Data Source=|DataDirectory|\\App\_Data\\LibraryDB.db;Version=3;"

&#x20;          providerName="System.Data.SQLite" />

&#x20; </connectionStrings>

&#x20; ```

\- \*\*Key:\*\* `LibraryDB` — must match the string used in `BookRepository` and `DatabaseInitializer`.

\- \*\*`|DataDirectory|`\*\* — .NET placeholder that resolves to the app's data folder at runtime.



\---



\### `UI/packages.config`

\- \*\*Purpose:\*\* Records which NuGet packages the project uses, so VS can restore them on build for teammates.



\---



\## 🗄️ Database Schema



\*\*Table:\*\* `Books`



| Column | Type | Constraints | Notes |

|--------|------|-------------|-------|

| `BookID` | INTEGER | PRIMARY KEY AUTOINCREMENT | Auto-assigned unique ID |

| `Title` | TEXT | NOT NULL | Book title |

| `Author` | TEXT | NOT NULL | Author name |

| `ISBN` | TEXT | NOT NULL, UNIQUE | No duplicates |

| `YearPublished` | INTEGER | NOT NULL | Year of publication |

| `Genre` | TEXT | NOT NULL | Category |

| `IsBorrowed` | INTEGER | NOT NULL, DEFAULT 0 | 0 = available, 1 = borrowed |



\*\*Location at runtime:\*\*

```

UI/bin/Debug/App\_Data/LibraryDB.db

```



\---



\## 🔄 Data Flow



```

User                UI                Controller           Repository          SQLite

&#x20;│                  │                     │                    │                 │

&#x20;│  clicks Add ─────►│                     │                    │                 │

&#x20;│                  │  AddBook(...) ─────►│                    │                 │

&#x20;│                  │                     │  validate ──► error│                 │

&#x20;│                  │                     │  AddBook(Book) ───►│                 │

&#x20;│                  │                     │                    │  INSERT ──────►│

&#x20;│                  │                     │                    │◄── success ───│

&#x20;│                  │◄─── "OK" ───────────│                    │                 │

&#x20;│  sees success ◄──│                     │                    │                 │

```



\---



\## 🚀 How to Run



\### Prerequisites

\- Visual Studio with the \*\*.NET desktop development\*\* workload

\- .NET Framework \*\*4.7.2\*\* (or higher)



\### Steps

1\. \*\*Clone\*\* the repository.

2\. \*\*Open\*\* `LibrarySolution.slnx` in Visual Studio.

3\. \*\*Restore NuGet packages\*\* — right-click solution → \*\*Restore NuGet Packages\*\*.

4\. \*\*Set `UI` as Startup Project\*\* — right-click `UI` → Set as Startup Project.

5\. Set \*\*Platform target\*\* to \*\*x64\*\* for `UI` and `BusinessLogic`.

6\. Press \*\*`F5`\*\* to build and run.

7\. On first run, `DatabaseInitializer.EnsureDatabase()` creates `LibraryDB.db` and seeds 5 books.

8\. The form displays the books — try \*\*Add\*\*, \*\*Update\*\*, \*\*Delete\*\*, \*\*Search\*\*.



\### Optional — Inspect the database

Install \*\*DB Browser for SQLite\*\* from https://sqlitebrowser.org/. Open:

```

LibrarySolution/UI/bin/Debug/App\_Data/LibraryDB.db

```

Click \*\*Browse Data\*\* → table \*\*Books\*\*.



\---



\## 📋 Summary Table — File Purpose in One Line



| File | Purpose |

|------|---------|

| `Model/Book.cs` | Blueprint of a book record |

| `BusinessLogic/Repository/DatabaseInitializer.cs` | Creates DB and seeds books on first run |

| `BusinessLogic/Repository/BookRepository.cs` | Runs SQL CRUD operations against SQLite |

| `BusinessLogic/Controller/BookController.cs` | Validates input and returns "OK" or error message |

| `DB/Table/Books.sql` | Documents the Books table schema |

| `DB/PostScript/SeedBooks.sql` | Documents the seed data |

| `UI/BookForm.cs` | Windows Form with grid and buttons |

| `UI/BookForm.Designer.cs` | Auto-generated UI layout |

| `UI/Program.cs` | Entry point — initializes DB, opens form |

| `UI/App.config` | SQLite connection string |



\---



\## 📄 License



This project was developed for academic purposes.

