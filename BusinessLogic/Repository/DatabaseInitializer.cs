using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;

namespace BusinessLogic.Repository
{
	public static class DatabaseInitializer
	{
		public static void EnsureDatabase()
		{
			// 1. Read connection string from App.config
			//
			// Sample output:
			//   connectionString = "Data Source=|DataDirectory|\App_Data\LibraryDB.db;Version=3;"
			//
			string connectionString = ConfigurationManager
				.ConnectionStrings["LibraryDB"].ConnectionString;

			// 2. Resolve |DataDirectory| for creating the folder
			//
			// Sample output:
			//   dataDirectory = "C:\Users\steph\source\repos\LibraryProject\UI\bin\Debug\"
			//
			string dataDirectory = AppDomain.CurrentDomain
				.GetData("DataDirectory")?.ToString()
				?? AppDomain.CurrentDomain.BaseDirectory;

			// Sample output:
			//   resolved = "Data Source=C:\Users\steph\source\repos\LibraryProject\UI\bin\Debug\\App_Data\LibraryDB.db;Version=3;"
			//
			string resolved = connectionString.Replace("|DataDirectory|", dataDirectory);

			// Sample output:
			//   builder.DataSource = "C:\Users\steph\source\repos\LibraryProject\UI\bin\Debug\App_Data\LibraryDB.db"
			//
			var builder = new SQLiteConnectionStringBuilder(resolved);
			string dbPath = builder.DataSource;

			// 3. Create the folder if missing
			//
			// Sample output:
			//   directory = "C:\Users\steph\source\repos\LibraryProject\UI\bin\Debug\App_Data"
			//   Directory exists? = false → creates it
			//   Directory exists? = true → skips
			//
			string directory = Path.GetDirectoryName(dbPath);
			if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			// 4. Open the database
			//
			// Sample output:
			//   Connection opens (creates LibraryDB.db if missing)
			//
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				// 5. Create Books table if missing (same as Books.sql)
				//
				// Sample output:
				//   If Books doesn't exist: runs CREATE TABLE → table created
				//   If Books already exists: no action (IF NOT EXISTS)
				//
				string createTable = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        BookID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        ISBN TEXT NOT NULL UNIQUE,
                        YearPublished INTEGER NOT NULL,
                        Genre TEXT NOT NULL,
                        IsBorrowed INTEGER NOT NULL DEFAULT 0
                    );";

				using (var cmd = new SQLiteCommand(createTable, conn))
				{
					cmd.ExecuteNonQuery();
				}

				// 6. Seed books if the table is empty (same as SeedBooks.sql)
				//
				// Sample output (first run):
				//   count = 0 → seeds 5 books
				// Sample output (second run):
				//   count = 5 → skips seeding
				//
				long count = 0;
				using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Books;", conn))
				{
					count = (long)cmd.ExecuteScalar();
				}

				if (count == 0)
				{
					// Sample: 5 rows inserted
					//   (1, 'The Hobbit',            'J.R.R. Tolkien',       '978-0261102217', 1937, 'Fantasy', 0)
					//   (2, '1984',                  'George Orwell',        '978-0451524935', 1949, 'Dystopian', 0)
					//   (3, 'To Kill a Mockingbird', 'Harper Lee',           '978-0061120084', 1960, 'Fiction', 0)
					//   (4, 'The Great Gatsby',      'F. Scott Fitzgerald',  '978-0743273565', 1925, 'Fiction', 0)
					//   (5, 'Pride and Prejudice',   'Jane Austen',          '978-0141439518', 1813, 'Romance', 0)
					//
					string seed = @"
                        INSERT INTO Books (Title, Author, ISBN, YearPublished, Genre) VALUES
                        ('The Hobbit',              'J.R.R. Tolkien',       '978-0261102217', 1937, 'Fantasy'),
                        ('1984',                    'George Orwell',        '978-0451524935', 1949, 'Dystopian'),
                        ('To Kill a Mockingbird',   'Harper Lee',           '978-0061120084', 1960, 'Fiction'),
                        ('The Great Gatsby',        'F. Scott Fitzgerald',  '978-0743273565', 1925, 'Fiction'),
                        ('Pride and Prejudice',     'Jane Austen',          '978-0141439518', 1813, 'Romance');";

					using (var cmd = new SQLiteCommand(seed, conn))
					{
						cmd.ExecuteNonQuery();
					}
				}
				// After this method:
				//   - The database file exists at bin/Debug/App_Data/LibraryDB.db
				//   - The Books table exists
				//   - 5 seed books are ready to be displayed
			}
		}
	}
}
