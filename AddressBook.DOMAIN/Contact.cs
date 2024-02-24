using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBook.DOMAIN
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        public string Name { get; set; }="";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public Contact() { }

        public Contact(string name, string email, string phone)
        {
            ValidateInputs(name, email, phone);

            // If the inputs are valid, set the properties.
            Name = name;
            Email = email;
            Phone = phone;
        }
       

        private void ValidateInputs(string name, string email, string phone)
        {
            
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email address.", nameof(email));

            if (!IsValidPhoneNumber(phone))
                throw new ArgumentException("Invalid phone number.", nameof(phone));
        }

        private bool IsValidEmail(string email)
        {
            // Basic email validation using a regular expression.
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email,
                       @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        }

        private bool IsValidPhoneNumber(string phone)
        {
            // Basic phone number validation for 10 characters.
            return !string.IsNullOrWhiteSpace(phone) && phone.Length == 10 && Regex.IsMatch(phone, @"^\d+$");
        }
    }

}

