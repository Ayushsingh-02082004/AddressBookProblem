using AddressManagemement.Entity;
using AddressManagemement.Interface;
using CsvHelper;
using System.Globalization;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AddressManagemement.services
{
    public class AdressBook : IAdressbook
    {

        private const string filePath = @"D:\BridgeLabs\Adressbook\adressbookdata\adressbook.txt";
        private const string csvFilePath = @"D:\BridgeLabs\Adressbook\adressbookdata\adressbook.csv";

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
                Console.WriteLine("Chose 5 to sort contact by name alphabetically and print.");
                Console.WriteLine("Chose 6 to sort contact by city alphabetically and print.");
                Console.WriteLine("Chose 7 to sort contact by state alphabetically and print.");
                Console.WriteLine("Chose 8 to sort contact by zipcode alphabetically and print.");
                Console.WriteLine("chose 9 to read contact from file");
                Console.WriteLine("chose 10 to write contact to file");
                Console.WriteLine("chose 11 to read contact from csvfile");
                Console.WriteLine("chose 12 to write contact to csvfile");
                Console.WriteLine("Chose 13 to stop the program");
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
                        SortContactByName();
                        break;
                    case "6":
                        SortByCity();
                        break;
                    case "7":
                        SortByState();
                        break;
                    case "8":
                        SortByZip();
                        break;
                    case "9":
                        ReadContactsFromFile();
                        break;
                    case "10":
                        WriteContactsToFile();
                        break;
                    case "11":
                        ReadCsvFile();
                        break;
                    case "12":
                        WriteCsvFile();
                        break;
                    case "13":
                        flag = false;
                        Console.WriteLine("program is stopped");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public void AddContact(Contacts contact)
        {
            if (contact == null) return;

            if (!list.Any(c => c.FirstName.ToLower().Equals(contact.FirstName.ToLower())))
            {
                list.Add(contact);
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

             // ✅ IMPORTANT: delegate to logic method
            AddContact(person);
            Console.WriteLine("Contact added successfully.");
        }

        public bool DeleteContact(String firstname)
        {

            if (string.IsNullOrWhiteSpace(firstname)) return false;

            int removedCount = list.RemoveAll(c => c.FirstName.Equals(firstname, StringComparison.OrdinalIgnoreCase));

            return removedCount > 0;
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
        public IReadOnlyList<Contacts> GetAllContacts()
        {
            return list.AsReadOnly();
        }

        public void SortContactByName()
        {
            if(list.Count == 0)
            {
                Console.WriteLine("List count is zero so can not be sorted.");
                return;
            }

            var sortedcontact = GetAllContacts().OrderBy(c => c.FirstName, StringComparer.OrdinalIgnoreCase).ThenBy(c => c.LastName , StringComparer.OrdinalIgnoreCase).ToList();

            Console.WriteLine("Contacts sorted alphabetically");
            foreach(var contact in sortedcontact)
            {
                Console.WriteLine(contact); // ToString() is called here.
            }

        }

        public List<Contacts> GetContactsSortedByName()
        {
            return list
                .OrderBy(c => c.FirstName, StringComparer.OrdinalIgnoreCase)
                .ThenBy(c => c.LastName, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public void SortByCity() //uc12
        {
            if(list.Count == 0)
            {
                Console.WriteLine("List is empty so can not be sorted");
                return;
            }

            var sortedbycity = list.OrderBy(c => c.City , StringComparer.OrdinalIgnoreCase).ThenBy(c => c.FirstName).ToList();
            Console.WriteLine("Contacts sorted by city");
            foreach(var contact in sortedbycity)
            {
                Console.WriteLine(contact);
            }
        }

        public void SortByState()//uc12
        {
            if (list.Count == 0)
            {
                Console.WriteLine("List is empty so can not be sorted");
                return;
            }

            var sortedbystate = list.OrderBy(c => c.State, StringComparer.OrdinalIgnoreCase).ThenBy(c => c.FirstName).ToList();
            Console.WriteLine("Contacts sorted by city");

            foreach(var contact in sortedbystate)
            {
                Console.WriteLine(contact);
            }
        }

        public void SortByZip()  //uc12
        {
            if(list.Count == 0)
            {
                Console.WriteLine("List is empty so can not be sorted");
                return;
            }

            var sortedbyZip = list.OrderBy(c => c.ZipCode).ThenBy(c => c.FirstName).ToList();
            Console.WriteLine("Contacts sorted by zip");

            foreach (var contact in sortedbyZip)
            {
                Console.WriteLine(contact);
            }
        }


        ////////---------------UC13--------------///////////

        public void WriteContactsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var contact in list)
                {
                    writer.WriteLine(
                        $"{contact.FirstName}|{contact.LastName}|{contact.Address}|" +
                        $"{contact.City}|{contact.State}|{contact.ZipCode}|" +
                        $"{contact.PhoneNumber}|{contact.Email}"
                    );
                }
            }

            Console.WriteLine("Contacts saved to AddressBook.txt successfully.");
        }


        public void ReadContactsFromFile()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("AddressBook.txt file not found.");
                return;
            }

            list.Clear();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] data = line.Split('|');
                if (data.Length != 8) continue;

                Contacts contact = new Contacts(
                    data[0], data[1], data[2], data[3],
                    data[4], data[5], data[6], data[7]
                );

                AddContact(contact);
                
            }
            Console.WriteLine("Contacts loaded from AddressBook.txt successfully.");
            DisplayContact();
        }

        /////////////////--------------UC14-----------------------/////////////


        public void WriteCsvFile()
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                // CSV Header
                writer.WriteLine("FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,Email");

                foreach (var contact in list)   // ✅ USE list
                {
                    writer.WriteLine(
                        $"{contact.FirstName},{contact.LastName},{contact.Address}," +
                        $"{contact.City},{contact.State},{contact.ZipCode}," +
                        $"{contact.PhoneNumber},{contact.Email}"
                    );
                }
            }
            Console.WriteLine("Contacts saved to AddressBook.csv successfully.");
        }

        public void ReadCsvFile()
        {
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine("AddressBook.csv file not found.");
                return;
            }

            list.Clear();

            string[] lines = File.ReadAllLines(csvFilePath);

            // start from index 1 to skip header
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] data = lines[i].Split(',');
                if (data.Length != 8) continue;

                Contacts contact = new Contacts(
                    data[0], data[1], data[2], data[3],
                    data[4], data[5], data[6], data[7]
                );

                AddContact(contact); // prevents duplicate first names
            }

            Console.WriteLine("Contacts loaded from AddressBook.csv successfully.");
            DisplayContact();
        }


    }
}
