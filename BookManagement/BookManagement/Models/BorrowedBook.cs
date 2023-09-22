﻿using System;
using System.Collections.Generic;

namespace BookManagement.Models;

public partial class BorrowedBook
{
    public int BorrowedId { get; set; }

    public int MemberId { get; set; }

    public int BookId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
