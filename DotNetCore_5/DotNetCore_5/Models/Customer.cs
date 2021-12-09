using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class Customer
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
