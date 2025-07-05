using System;
using System.Collections.Generic;

namespace Examen_P2.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
