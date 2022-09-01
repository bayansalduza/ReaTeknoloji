using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaTeknoloji.Data.Dto
{
    public class UpdateCustomerRequestDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public string Password { get; set; }
    }
}
