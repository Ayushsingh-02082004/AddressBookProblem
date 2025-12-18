using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagemement.Entity
{
    internal class AdressBook
    {
        private Contacts contact;

        public void addContact(Contacts person)
        {
            contact = person;
            Console.WriteLine("Contact added successfully");
        }

        public void DisplayContact()
        {
            if (contact == null)
            {
                Console.WriteLine("No contact available.");
                return;
            }

            Console.WriteLine("----- Contact Details -----");
            Console.WriteLine($"First Name : {contact.FirstName}");
            Console.WriteLine($"Last Name  : {contact.LastName}");
            Console.WriteLine($"Address    : {contact.Address}");
            Console.WriteLine($"City       : {contact.City}");
            Console.WriteLine($"State      : {contact.State}");
            Console.WriteLine($"Zip Code   : {contact.ZipCode}");
            Console.WriteLine($"Phone No   : {contact.PhoneNumber}");
            Console.WriteLine($"Email      : {contact.Email}");
        }

    }
}
