using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
       
        [Display(Name = "Email")]
       
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Email is Reqired")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        [Display(Name = "Purchase Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public int UnitPrice { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }      
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }

        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        [Display(Name = "Image Name")]
        public IFormFile Photo { get; set; }
    }
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
