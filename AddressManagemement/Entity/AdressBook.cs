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

        public void editContact(String firstname)
        {
            if(firstname == null || contact == null)
            {
                Console.WriteLine("No contact available.");
                return;
            }
            if (contact.FirstName.Equals(firstname , StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Editing Contact Details:");

                Console.Write("Enter New Address: ");
                contact.Address = Console.ReadLine();

                Console.Write("Enter New City: ");
                contact.City = Console.ReadLine();

                Console.Write("Enter New State: ");
                contact.State = Console.ReadLine();

                Console.Write("Enter New Zip Code: ");
                contact.ZipCode = Console.ReadLine();

                Console.Write("Enter New Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();

                Console.Write("Enter New Email: ");
                contact.Email = Console.ReadLine();

                Console.WriteLine("\nContact updated successfully.");
            }
            else Console.WriteLine("There is no contact of this .");
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
