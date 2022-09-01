using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaTeknoloji.Data.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [ForeignKey("Address_FK_Order")]
        public int AddressId { get; set; }
        public Address Address { get; set; }


        [ForeignKey("Product_FK_Order")]
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }


        [ForeignKey("Customer_FK_Order")]
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
