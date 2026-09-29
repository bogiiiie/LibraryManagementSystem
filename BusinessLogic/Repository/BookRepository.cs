using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using Model;

namespace BusinessLogic.Repository
{
	public class BookRepository
	{
		private readonly string connectionString;

		public BookRepository()
		{
			connectionString = ConfigurationManager
				.ConnectionStrings["LibraryDB"].ConnectionString;
		}

		public List<Book> GetAllBooks()
		{
			List<Book> books = new List<Book>();

			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				string sql = "SELECT BookID, Title, Author, ISBN, YearPublished, Genre, IsBorrowed FROM Books;";

				using (var cmd = new SQLiteCommand(sql, conn))
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						books.Add(new Book
						{
							BookID = Convert.ToInt32(reader["BookID"]),
							Title = reader["Title"].ToString(),
							Author = reader["Author"].ToString(),
							ISBN = reader["ISBN"].ToString(),
							YearPublished = Convert.ToInt32(reader["YearPublished"]),
							Genre = reader["Genre"].ToString(),
							IsBorrowed = Convert.ToInt32(reader["IsBorrowed"]) == 1
						});
					}
				}
			}

			return books;
		}

		public void AddBook(Book book)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				string sql = "INSERT INTO Books (Title, Author, ISBN, YearPublished, Genre, IsBorrowed) " +
							 "VALUES (@Title, @Author, @ISBN, @YearPublished, @Genre, @IsBorrowed);";

				using (var cmd = new SQLiteCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@Title", book.Title);
					cmd.Parameters.AddWithValue("@Author", book.Author);
					cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
					cmd.Parameters.AddWithValue("@YearPublished", book.YearPublished);
					cmd.Parameters.AddWithValue("@Genre", book.Genre);
					cmd.Parameters.AddWithValue("@IsBorrowed", book.IsBorrowed ? 1 : 0);

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void UpdateBook(Book book)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				string sql = "UPDATE Books SET Title = @Title, Author = @Author, " +
							 "YearPublished = @YearPublished, Genre = @Genre, " +
							 "IsBorrowed = @IsBorrowed WHERE BookID = @BookID;";

				using (var cmd = new SQLiteCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@BookID", book.BookID);
					cmd.Parameters.AddWithValue("@Title", book.Title);
					cmd.Parameters.AddWithValue("@Author", book.Author);
					cmd.Parameters.AddWithValue("@YearPublished", book.YearPublished);
					cmd.Parameters.AddWithValue("@Genre", book.Genre);
					cmd.Parameters.AddWithValue("@IsBorrowed", book.IsBorrowed ? 1 : 0);

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void DeleteBook(int bookID)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				string sql = "DELETE FROM Books WHERE BookID = @BookID;";

				using (var cmd = new SQLiteCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@BookID", bookID);
					cmd.ExecuteNonQuery();
				}
			}
		}

		public List<Book> SearchBooks(string keyword)
		{
			List<Book> books = new List<Book>();

			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				string sql = "SELECT BookID, Title, Author, ISBN, YearPublished, Genre, IsBorrowed " +
							 "FROM Books " +
							 "WHERE Title LIKE @Keyword OR Author LIKE @Keyword OR ISBN LIKE @Keyword;";

				using (var cmd = new SQLiteCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							books.Add(new Book
							{
								BookID = Convert.ToInt32(reader["BookID"]),
								Title = reader["Title"].ToString(),
								Author = reader["Author"].ToString(),
								ISBN = reader["ISBN"].ToString(),
								YearPublished = Convert.ToInt32(reader["YearPublished"]),
								Genre = reader["Genre"].ToString(),
								IsBorrowed = Convert.ToInt32(reader["IsBorrowed"]) == 1
							});
						}
					}
				}
			}

			return books;
		}

		public Book GetBookByISBN(string isbn)
		{
			Book book = null;

			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				string sql = "SELECT BookID, Title, Author, ISBN, YearPublished, Genre, IsBorrowed " +
							 "FROM Books WHERE ISBN = @ISBN LIMIT 1;";

				using (var cmd = new SQLiteCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@ISBN", isbn);

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							book = new Book
							{
								BookID = Convert.ToInt32(reader["BookID"]),
								Title = reader["Title"].ToString(),
								Author = reader["Author"].ToString(),
								ISBN = reader["ISBN"].ToString(),
								YearPublished = Convert.ToInt32(reader["YearPublished"]),
								Genre = reader["Genre"].ToString(),
								IsBorrowed = Convert.ToInt32(reader["IsBorrowed"]) == 1
							};
						}
					}
				}
			}

			return book;
		}

		public Book GetBookByID(int bookID)
		{
			Book book = null;

			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Open();

				string sql = "SELECT BookID, Title, Author, ISBN, YearPublished, Genre, IsBorrowed " +
							 "FROM Books WHERE BookID = @BookID LIMIT 1;";

				using (var cmd = new SQLiteCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@BookID", bookID);

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							book = new Book
							{
								BookID = Convert.ToInt32(reader["BookID"]),
								Title = reader["Title"].ToString(),
								Author = reader["Author"].ToString(),
								ISBN = reader["ISBN"].ToString(),
								YearPublished = Convert.ToInt32(reader["YearPublished"]),
								Genre = reader["Genre"].ToString(),
								IsBorrowed = Convert.ToInt32(reader["IsBorrowed"]) == 1
							};
						}
					}
				}
			}

			return book;
		}
	}
}