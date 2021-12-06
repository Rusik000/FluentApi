using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
