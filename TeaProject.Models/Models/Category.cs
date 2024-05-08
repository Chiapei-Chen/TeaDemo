using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeaProject.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? DisplayOrder { get; set; }
}
