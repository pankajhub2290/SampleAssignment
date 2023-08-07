using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SampleAssignment.WebApp.Models
{
    public class CustomerViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address1 is required.")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }
        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "PostalCode is required.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }    
    }
}
