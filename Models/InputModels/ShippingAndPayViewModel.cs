using System.ComponentModel.DataAnnotations;


namespace BookCave.Models.InputModels
{
    public class ShippingAndPayViewModel
    {
        [Required(ErrorMessage = "Please put in your name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please put in your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please put in your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please put in city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please put in zipcode")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "Please choose country")]
        public string country { get; set; }

        [Required(ErrorMessage = "Please put in cardholder name")]
        public string CardholderName { get; set; }

        [Required(ErrorMessage = "Please put in your card informations")]
        public int CardNumber { get; set; }

        [Required(ErrorMessage = "Please select exp date")]
        public int expdate { get; set; }

        [Required(ErrorMessage = "Please insert CVV security number")]
        public int CVV { get; set; }


    }
}