using AddressManagemement.Entity;
using AddressManagemement.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagemement.services
{
    internal class AdressBook : IAdressbook
    {
        private List<Contacts> list = new List<Contacts>();

        public void AdressBookOperation()
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("--------------------------AdressBook_____________________________");
                Console.WriteLine("Chose 1 for AddingContact");
                Console.WriteLine("Chose 2 for DeletingContat");
                Console.WriteLine("Chose 3 for EditContact");
                Console.WriteLine("Chose 4 for DisplayProgram");
                Console.WriteLine("Chose 5 to stop the program");

                Console.WriteLine("Choose Option: ");

                String choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        Console.WriteLine("Enter first name for deleting Contact");
                        DeleteContact(Console.ReadLine());
                        break;
                    case "3":
                        Console.WriteLine("Enter first name for editing contact");
                        EditContact(Console.ReadLine());
                        break;
                    case "4":
                        DisplayContact();
                        break;
                    case "5":
                        flag = false;
                        Console.WriteLine("program is stopped");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public void AddContact()
        {
            Console.WriteLine("Enter First Name:");
            string firstname = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastname = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();

            Console.WriteLine("Enter State:");
            string state = Console.ReadLine();

            Console.WriteLine("Enter Zip Code:");
            string zip = Console.ReadLine();

            Console.WriteLine("Enter Phone Number:");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            // ✅ Constructor called ONCE with proper data
            Contacts person = new Contacts(
                firstname,
                lastname,
                address,
                city,
                state,
                zip,
                phone,
                email
            );

            list.Add(person);
            Console.WriteLine("Contact added successfully.");
        }

        public void DeleteContact(String firstname)
        {

            if (list.Count == 0 || firstname == null)
            {
                Console.WriteLine("No contact available.");
                return;
            }

            Contacts contacttodelete = null;
            foreach(Contacts contact in list)
            {
                if (contact.FirstName.Equals(firstname, StringComparison.OrdinalIgnoreCase))
                {
                    contacttodelete = contact;
                    break;
                }

            }
            if (contacttodelete != null)
            {
                list.Remove(contacttodelete);
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }

        }

        public void EditContact(String firstname)
        {
            if(firstname == null || list.Count == 0)
            {
                Console.WriteLine("No contact available.");
                return;
            }
            foreach (Contacts contact in list)
            {
                if(contact.FirstName.Equals(firstname , StringComparison.OrdinalIgnoreCase))
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
                    return;
                }
            }
            Console.WriteLine("There is no contact of this .");
        }
        public void DisplayContact()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No contact available.");
                return;
            }

            foreach(Contacts contact in list)
            {
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
}
