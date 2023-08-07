using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SampleAssignment.WebApp.Models
{
    public class CustomerListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
