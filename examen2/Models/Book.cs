using System;
using System.Collections.Generic;

namespace examen2.Models;

public partial class Book
{
    public int Id { get; set; }

    public int IdAuthor { get; set; }

    public string Title { get; set; } = null!;

    public int Chapters { get; set; }

    public int Pages { get; set; }

    public double Price { get; set; }

    public virtual Author? IdAuthorNavigation { get; set; } = null!;
}
