using AddressManagemement.ExceptionHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressManagemement.Entity
{
    public class Contacts
    {
        private string firstname;
        private string lastname;
        private string address;
        private string city;
        private string state;
        private string zipcode;
        private string phonenumber;
        private string email;

        public string FirstName
        {
            get { return firstname; }
            set {firstname = value;}
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string ZipCode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                string pattern = @"^[6-9]\d{9,}$";
                if ( Regex.IsMatch(value , pattern))
                {
                    phonenumber = value;
                }
                else
                {
                    throw new PhoneNumberException("Invalid phonw number");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
                if (Regex.IsMatch(value , pattern))
                {
                    email = value;
                }
                else
                {
                    throw new EmailException("Invalid email format");
                }
            }
        }

        public Contacts(string firstname, string lastname, string address, string city, string state, string zipcode, string phonenumber, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;

            PhoneNumber = phonenumber;
            Email = email;

        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Contacts))
                return false;

            Contacts other = (Contacts)obj;

            return string.Equals(this.FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
        }


        public override int GetHashCode()
        {
            return (firstname.ToLower() + lastname.ToLower()).GetHashCode();
        }

    }

}
