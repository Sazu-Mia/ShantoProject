CREATE DATABASE BookDb
GO
USE BookDb
GO
CREATE TABLE Books (
    BookID INT IDENTITY PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    PublicationYear INT NOT NULL,
	Price MONEY NOT  NULL,
	TotalPage INT NOT NULL
);
GO
CREATE TABLE Members (
    MemberID INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NULL,
    Email VARCHAR(100) NOT NULL,
	[Address] VARCHAR(100) NOT NULL
);
GO
CREATE TABLE BorrowedBooks (
    BorrowedID  INT IDENTITY PRIMARY KEY,
    MemberID INT NOT NULL,
    BookID INT NOT NULL,
    BorrowDate DATE NOT NULL,
    ReturnDate DATE NOT NULL,
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
GO
INSERT INTO Books
VALUES ('The Lord of the Rings', 'J.R.R. Tolkien', 1990, 2300, 500),
('The Art of War', 'Sun Tzu', 18710, 3400, 350)
GO
INSERT INTO Members
VALUES ('Mr. X', 'Khan', 'mrs@gmail.com', 'Dhaka'),
('Mr. Y', 'Uddin', 'mys@gmail.com', 'Khulna')
GO
INSERT INTO BorrowedBooks
VALUES (1, 1, '2023-03-11', '2023-05-12'),
(2, 2, '2021-03-11', '2021-09-12')
GO