using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vanity.API.Models;

public partial class Book
{
    [Key]
    public int BookId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }
}
