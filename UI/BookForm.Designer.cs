namespace UI
{
	partial class BookForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblHeader = new System.Windows.Forms.Label();
			this.lblTitleLabel = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.lblISBNLabel = new System.Windows.Forms.Label();
			this.txtISBN = new System.Windows.Forms.TextBox();
			this.lblAuthorLabel = new System.Windows.Forms.Label();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.lblYearLabel = new System.Windows.Forms.Label();
			this.txtYear = new System.Windows.Forms.TextBox();
			this.lblGenreLabel = new System.Windows.Forms.Label();
			this.txtGenre = new System.Windows.Forms.TextBox();
			this.chkBorrowed = new System.Windows.Forms.CheckBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.lblSearchLabel = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lblCount = new System.Windows.Forms.Label();
			this.dgvBooks = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
			this.SuspendLayout();
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
			this.lblHeader.Location = new System.Drawing.Point(20, 20);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(269, 29);
			this.lblHeader.TabIndex = 0;
			this.lblHeader.Text = "Library Book Manager";
			// 
			// lblTitleLabel
			// 
			this.lblTitleLabel.AutoSize = true;
			this.lblTitleLabel.Location = new System.Drawing.Point(20, 70);
			this.lblTitleLabel.Name = "lblTitleLabel";
			this.lblTitleLabel.Size = new System.Drawing.Size(33, 16);
			this.lblTitleLabel.TabIndex = 1;
			this.lblTitleLabel.Text = "Title";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(80, 67);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(200, 22);
			this.txtTitle.TabIndex = 2;
			// 
			// lblISBNLabel
			// 
			this.lblISBNLabel.AutoSize = true;
			this.lblISBNLabel.Location = new System.Drawing.Point(320, 70);
			this.lblISBNLabel.Name = "lblISBNLabel";
			this.lblISBNLabel.Size = new System.Drawing.Size(38, 16);
			this.lblISBNLabel.TabIndex = 3;
			this.lblISBNLabel.Text = "ISBN";
			// 
			// txtISBN
			// 
			this.txtISBN.Location = new System.Drawing.Point(380, 67);
			this.txtISBN.Name = "txtISBN";
			this.txtISBN.Size = new System.Drawing.Size(200, 22);
			this.txtISBN.TabIndex = 4;
			// 
			// lblAuthorLabel
			// 
			this.lblAuthorLabel.AutoSize = true;
			this.lblAuthorLabel.Location = new System.Drawing.Point(20, 110);
			this.lblAuthorLabel.Name = "lblAuthorLabel";
			this.lblAuthorLabel.Size = new System.Drawing.Size(45, 16);
			this.lblAuthorLabel.TabIndex = 5;
			this.lblAuthorLabel.Text = "Author";
			// 
			// txtAuthor
			// 
			this.txtAuthor.Location = new System.Drawing.Point(80, 107);
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.Size = new System.Drawing.Size(200, 22);
			this.txtAuthor.TabIndex = 6;
			// 
			// lblYearLabel
			// 
			this.lblYearLabel.AutoSize = true;
			this.lblYearLabel.Location = new System.Drawing.Point(320, 110);
			this.lblYearLabel.Name = "lblYearLabel";
			this.lblYearLabel.Size = new System.Drawing.Size(36, 16);
			this.lblYearLabel.TabIndex = 7;
			this.lblYearLabel.Text = "Year";
			// 
			// txtYear
			// 
			this.txtYear.Location = new System.Drawing.Point(380, 107);
			this.txtYear.Name = "txtYear";
			this.txtYear.Size = new System.Drawing.Size(200, 22);
			this.txtYear.TabIndex = 8;
			// 
			// lblGenreLabel
			// 
			this.lblGenreLabel.AutoSize = true;
			this.lblGenreLabel.Location = new System.Drawing.Point(20, 150);
			this.lblGenreLabel.Name = "lblGenreLabel";
			this.lblGenreLabel.Size = new System.Drawing.Size(44, 16);
			this.lblGenreLabel.TabIndex = 9;
			this.lblGenreLabel.Text = "Genre";
			// 
			// txtGenre
			// 
			this.txtGenre.Location = new System.Drawing.Point(80, 147);
			this.txtGenre.Name = "txtGenre";
			this.txtGenre.Size = new System.Drawing.Size(200, 22);
			this.txtGenre.TabIndex = 10;
			// 
			// chkBorrowed
			// 
			this.chkBorrowed.AutoSize = true;
			this.chkBorrowed.Location = new System.Drawing.Point(380, 149);
			this.chkBorrowed.Name = "chkBorrowed";
			this.chkBorrowed.Size = new System.Drawing.Size(100, 20);
			this.chkBorrowed.TabIndex = 11;
			this.chkBorrowed.Text = "Is Borrowed";
			this.chkBorrowed.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(23, 190);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(80, 30);
			this.btnAdd.TabIndex = 12;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(109, 190);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(80, 30);
			this.btnUpdate.TabIndex = 13;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(195, 190);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(80, 30);
			this.btnDelete.TabIndex = 14;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(281, 190);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(80, 30);
			this.btnClear.TabIndex = 15;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(367, 190);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(100, 30);
			this.btnRefresh.TabIndex = 16;
			this.btnRefresh.Text = "Refresh All";
			this.btnRefresh.UseVisualStyleBackColor = true;
			// 
			// lblSearchLabel
			// 
			this.lblSearchLabel.AutoSize = true;
			this.lblSearchLabel.Location = new System.Drawing.Point(20, 240);
			this.lblSearchLabel.Name = "lblSearchLabel";
			this.lblSearchLabel.Size = new System.Drawing.Size(50, 16);
			this.lblSearchLabel.TabIndex = 17;
			this.lblSearchLabel.Text = "Search";
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(80, 237);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 22);
			this.txtSearch.TabIndex = 18;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(290, 235);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(80, 26);
			this.btnSearch.TabIndex = 19;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Location = new System.Drawing.Point(20, 275);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(93, 16);
			this.lblCount.TabIndex = 20;
			this.lblCount.Text = "Total Books: 0";
			// 
			// dgvBooks
			// 
			this.dgvBooks.AllowUserToAddRows = false;
			this.dgvBooks.AllowUserToDeleteRows = false;
			this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
			this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBooks.Location = new System.Drawing.Point(23, 310);
			this.dgvBooks.Name = "dgvBooks";
			this.dgvBooks.ReadOnly = true;
			this.dgvBooks.RowHeadersVisible = false;
			this.dgvBooks.RowHeadersWidth = 51;
			this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvBooks.Size = new System.Drawing.Size(720, 250);
			this.dgvBooks.TabIndex = 21;
			this.dgvBooks.SelectionChanged += new System.EventHandler(this.dgvBooks_SelectionChanged);
			// 
			// BookForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(780, 600);
			this.Controls.Add(this.dgvBooks);
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.lblSearchLabel);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.chkBorrowed);
			this.Controls.Add(this.txtGenre);
			this.Controls.Add(this.lblGenreLabel);
			this.Controls.Add(this.txtYear);
			this.Controls.Add(this.lblYearLabel);
			this.Controls.Add(this.txtAuthor);
			this.Controls.Add(this.lblAuthorLabel);
			this.Controls.Add(this.txtISBN);
			this.Controls.Add(this.lblISBNLabel);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.lblTitleLabel);
			this.Controls.Add(this.lblHeader);
			this.Name = "BookForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Library Book Manager";
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.Label lblTitleLabel;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label lblISBNLabel;
		private System.Windows.Forms.TextBox txtISBN;
		private System.Windows.Forms.Label lblAuthorLabel;
		private System.Windows.Forms.TextBox txtAuthor;
		private System.Windows.Forms.Label lblYearLabel;
		private System.Windows.Forms.TextBox txtYear;
		private System.Windows.Forms.Label lblGenreLabel;
		private System.Windows.Forms.TextBox txtGenre;
		private System.Windows.Forms.CheckBox chkBorrowed;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label lblSearchLabel;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.DataGridView dgvBooks;
	}
}