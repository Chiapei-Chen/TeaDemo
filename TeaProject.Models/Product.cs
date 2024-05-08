using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }


        public string Temperature { get; set; }

        //建立關聯
     [ForeignKey(nameof(CategoryId))] //明確定義此類別屬性用於FK
        public int CategoryId { get; set; }

      public Category Category { get; set; } //告訴模型會使用到類別表

    }
}
