using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogic.Controller;
using Model;

namespace UI
{
	public partial class BookForm : Form
	{
		// The controller is the bridge to the database
		private readonly BookController controller = new BookController();

		public BookForm()
		{
			InitializeComponent();
		}

		// =============================================================
		// FORM LOAD — loads all books when the form opens
		// =============================================================
		private void BookForm_Load(object sender, EventArgs e)
		{
			LoadBooks();
		}

		// =============================================================
		// LOAD ALL — reads from the DATABASE
		// =============================================================
		private void LoadBooks()
		{
			List<Book> books = controller.GetAllBooks();

			dgvBooks.DataSource = null;
			dgvBooks.DataSource = books;

			lblCount.Text = "Total Books: " + books.Count;
		}

		// =============================================================
		// ROW SELECTION — fills textboxes with the clicked book
		// =============================================================
		private void dgvBooks_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvBooks.CurrentRow == null) return;

			Book selected = dgvBooks.CurrentRow.DataBoundItem as Book;
			if (selected == null) return;

			txtTitle.Text = selected.Title;
			txtAuthor.Text = selected.Author;
			txtISBN.Text = selected.ISBN;
			txtYear.Text = selected.YearPublished.ToString();
			txtGenre.Text = selected.Genre;
			chkBorrowed.Checked = selected.IsBorrowed;
		}

		// =============================================================
		// ADD — saves to the DATABASE via the controller
		// =============================================================
		private void btnAdd_Click(object sender, EventArgs e)
		{
			int year;
			if (!int.TryParse(txtYear.Text, out year))
			{
				MessageBox.Show("Year must be a number.");
				return;
			}

			string result = controller.AddBook(
				txtTitle.Text.Trim(),
				txtAuthor.Text.Trim(),
				txtISBN.Text.Trim(),
				year,
				txtGenre.Text.Trim()
			);

			ShowResult(result);
		}

		// =============================================================
		// UPDATE — saves changes to the DATABASE
		// =============================================================
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (dgvBooks.CurrentRow == null)
			{
				MessageBox.Show("Select a book first.");
				return;
			}

			Book selected = dgvBooks.CurrentRow.DataBoundItem as Book;
			if (selected == null) return;

			int year;
			if (!int.TryParse(txtYear.Text, out year))
			{
				MessageBox.Show("Year must be a number.");
				return;
			}

			string result = controller.UpdateBook(
				selected.BookID,
				txtTitle.Text.Trim(),
				txtAuthor.Text.Trim(),
				year,
				txtGenre.Text.Trim(),
				chkBorrowed.Checked
			);

			ShowResult(result);
		}

		// =============================================================
		// DELETE — removes from the DATABASE
		// =============================================================
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvBooks.CurrentRow == null)
			{
				MessageBox.Show("Select a book first.");
				return;
			}

			Book selected = dgvBooks.CurrentRow.DataBoundItem as Book;
			if (selected == null) return;

			DialogResult confirm = MessageBox.Show(
				"Delete this book?", "Confirm",
				MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (confirm != DialogResult.Yes) return;

			string result = controller.DeleteBook(selected.BookID);
			ShowResult(result);
		}

		// =============================================================
		// SEARCH — queries the DATABASE
		// =============================================================
		private void btnSearch_Click(object sender, EventArgs e)
		{
			List<Book> results = controller.SearchBooks(txtSearch.Text.Trim());

			dgvBooks.DataSource = null;
			dgvBooks.DataSource = results;

			lblCount.Text = "Total Books: " + results.Count;

			if (results.Count == 0)
				MessageBox.Show("No books found.");
		}

		// =============================================================
		// CLEAR — resets the form
		// =============================================================
		private void btnClear_Click(object sender, EventArgs e)
		{
			txtTitle.Clear();
			txtAuthor.Clear();
			txtISBN.Clear();
			txtYear.Clear();
			txtGenre.Clear();
			chkBorrowed.Checked = false;
			txtSearch.Clear();
			LoadBooks();
		}

		// =============================================================
		// REFRESH — reloads from DATABASE
		// =============================================================
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadBooks();
		}

		// =============================================================
		// HELPER — shows result and refreshes
		// =============================================================
		private void ShowResult(string result)
		{
			if (result == "OK")
			{
				MessageBox.Show("Success!", "OK",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadBooks();
				btnClear_Click(null, null);
			}
			else
			{
				MessageBox.Show(result, "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}