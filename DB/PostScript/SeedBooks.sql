-- Purpose: Insert sample books for testing.
-- The same SQL runs at runtime from
-- DatabaseInitializer.cs.
INSERT INTO Books (Title, Author, ISBN, YearPublished, Genre) VALUES
('The Hobbit',              'J.R.R. Tolkien',       '978-0261102217', 1937, 'Fantasy'),
('1984',                    'George Orwell',        '978-0451524935', 1949, 'Dystopian'),
('To Kill a Mockingbird',   'Harper Lee',           '978-0061120084', 1960, 'Fiction'),
('The Great Gatsby',        'F. Scott Fitzgerald',  '978-0743273565', 1925, 'Fiction'),
('Pride and Prejudice',     'Jane Austen',          '978-0141439518', 1813, 'Romance');