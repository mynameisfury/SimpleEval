using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleEval.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public int InStockQuantity { get; set; }
    }
}