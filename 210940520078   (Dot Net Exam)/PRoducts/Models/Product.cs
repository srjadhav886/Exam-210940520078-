using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    {
        
        public int ProductId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter ProductName")]
        public string ProductName { get; set; }
        public decimal Rate { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter CategoryName")]
        public string CategoryName { get; set; }
    }
}