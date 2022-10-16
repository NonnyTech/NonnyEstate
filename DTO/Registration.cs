using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nonny_Estate.Models
{
    public enum EntryMonth
    {
        January, february, March, April, May, June, July, August, September, October, November,
        December
    }
    public enum ApartmentSize
    {
        Onebedroom, TwoBedroom, ThreebedRoom, SelfContain, Duplex
    }
    public class Registration
    {
                [Key]
        [Required(ErrorMessage = "Please enter your ID Number")]
        [Display(Name = "Identiy Number")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your Last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Email address")]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password did not match, Please check again")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please enter number of cars")]
        [Display(Name = "Number of cars")]

        public int NoOfCars { get; set; }
        [Required(ErrorMessage = "Please enter the Month and year of entry")]
        [Display(Name = "What year did you move into the estate")]
        public EntryMonth Type { get; set; }
        [Required(ErrorMessage = "Please the nature of your building")]
        [Display(Name = "Nature of building")]
        public ApartmentSize Building { get; set; }




    }
}

