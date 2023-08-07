using SampleAssignment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAssignment.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public Address Address { get; set; }
        public void SetAddress(Address address)
        {
            Address = address ?? throw new ArgumentNullException("address");
        }
    }
}
