using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI_backend.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Precio debe ser mayor a 1")]
        public decimal Price { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Stock debe ser mayor a 0")]
        public int Stock { get; set; }
    }
}
