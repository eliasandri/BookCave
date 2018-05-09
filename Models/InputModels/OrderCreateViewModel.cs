using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookCave.Data.EntityModels;

namespace BookCave.Models.InputModels
{
    public class OrderCreateViewModel
    {
        public string Username { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public double Total { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public int PromoCode { get; set; }

        [Required(ErrorMessage = "Please put in cardholder name")]
        public string CardholderName { get; set; }

        [Required(ErrorMessage = "Please put in your card informations")]
        public int CardNumber { get; set; }

        [Required(ErrorMessage = "Please select exp date")]
        public int Expdate { get; set; }

        [Required(ErrorMessage = "Please insert CVV security number")]
        public int CVV { get; set; }
    }
}