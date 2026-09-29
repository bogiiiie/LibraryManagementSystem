using System;
using System.Collections.Generic;
using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
	public class BookController
	{
		private readonly BookRepository repository = new BookRepository();

		public List<Book> GetAllBooks()
		{
			return repository.GetAllBooks();
		}

		public Book GetBookByISBN(string isbn)
		{
			return repository.GetBookByISBN(isbn);
		}

		public string AddBook(string title, string author, string isbn, int year, string genre)
		{
			// Validation
			if (string.IsNullOrWhiteSpace(title))
				return "Title is required.";

			if (string.IsNullOrWhiteSpace(author))
				return "Author is required.";

			if (string.IsNullOrWhiteSpace(isbn))
				return "ISBN is required.";

			if (year < 1000 || year > DateTime.Now.Year)
				return "Year published is invalid.";

			if (string.IsNullOrWhiteSpace(genre))
				return "Genre is required.";

			// Check for duplicate ISBN
			Book existing = repository.GetBookByISBN(isbn);
			if (existing != null)
				return "A book with this ISBN already exists.";

			// Build the Book object
			Book book = new Book
			{
				Title = title,
				Author = author,
				ISBN = isbn,
				YearPublished = year,
				Genre = genre,
				IsBorrowed = false
			};

			// Save
			repository.AddBook(book);
			return "OK";
		}

		public string UpdateBook(int bookID, string title, string author, int year, string genre, bool isBorrowed)
		{
			if (string.IsNullOrWhiteSpace(title))
				return "Title is required.";

			if (string.IsNullOrWhiteSpace(author))
				return "Author is required.";

			if (year < 1000 || year > DateTime.Now.Year)
				return "Year published is invalid.";

			Book book = new Book
			{
				BookID = bookID,
				Title = title,
				Author = author,
				YearPublished = year,
				Genre = genre,
				IsBorrowed = isBorrowed
			};

			repository.UpdateBook(book);
			return "OK";
		}

		public string DeleteBook(int bookID)
		{
			Book existing = repository.GetBookByID(bookID);
			if (existing == null)
				return "Book not found.";

			if (existing.IsBorrowed)
				return "Cannot delete a borrowed book.";

			repository.DeleteBook(bookID);
			return "OK";
		}

		public List<Book> SearchBooks(string keyword)
		{
			if (string.IsNullOrWhiteSpace(keyword))
				return repository.GetAllBooks();

			return repository.SearchBooks(keyword);
		}
	}
}