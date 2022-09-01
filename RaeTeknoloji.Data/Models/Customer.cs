using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaTeknoloji.Data.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Password { get; set; }
        public string? CurrentToken { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Address_FK_Customer")]
        [Required]
        public int AddressId { get; set; }
        [Required]
        public Address Address { get; set; } 
    }
}
