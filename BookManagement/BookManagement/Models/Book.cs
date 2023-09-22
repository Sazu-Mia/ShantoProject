using System;
using System.Collections.Generic;

namespace BookManagement.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int PublicationYear { get; set; }

    public decimal Price { get; set; }

    public int TotalPage { get; set; }

    public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
}
