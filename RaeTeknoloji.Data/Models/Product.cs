using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaTeknoloji.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImageUri { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
