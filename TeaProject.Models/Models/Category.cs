using System;
using System.Collections.Generic;

namespace TeaProject.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? DisplayOrder { get; set; }
}
