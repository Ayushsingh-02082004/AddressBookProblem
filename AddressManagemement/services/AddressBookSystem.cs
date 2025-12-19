using AddressManagemement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagemement.services
{
    internal class AddressBookSystem
    {

        private Dictionary<String , AdressBook> AdressLibrary = new Dictionary<String , AdressBook>(StringComparer.OrdinalIgnoreCase);

        public void AdressLibraryOperation()
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("------------------------------------Opration in Adress Library---------------------------------------");
                Console.WriteLine("Press 1 to Enter new Adressbook in library");
                Console.WriteLine("press 2 to Display books present in the library");
                Console.WriteLine("Press 3 to Select the book from library");
                Console.WriteLine("press 4 to search person from city");
                Console.WriteLine("press 5 to search person from state");
                Console.WriteLine("press 6 to Exit from the library");

                Console.WriteLine("Choose the option : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddnewAdressBook();
                        break;
                    case "2":
                        DisplayAdressLibrary();
                        break;
                    case "3":
                        SelectAdressBook();
                        break;
                    case "4":
                        SearchByCity();
                        break;
                    case "5":
                        SearchByState();
                        break;
                    case "6":
                        flag = false;
                        Console.WriteLine("Exited successfully from the library.");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            
        }

        private void AddnewAdressBook()
        {

            Console.WriteLine("Enter the name of adressbook : ");
            String name = Console.ReadLine();

            if(AdressLibrary.ContainsKey( name))
            {
                Console.WriteLine("Adress book already exists.");
                return;
            }

            AdressLibrary[name] = new AdressBook();
            Console.WriteLine("Adress book added successfully.");
        }

        private void DisplayAdressLibrary()
        {
            if(AdressLibrary.Count == 0)
            {
                Console.WriteLine("AdressLibrary is empty");
                return;
            }

            foreach(var book in AdressLibrary.Keys)
            {
                Console.WriteLine(" _ " + book); 
            }

        }

        private void SelectAdressBook()
        {

            Console.WriteLine("Enter the name of adressboook you want to select : ");
            String name = Console.ReadLine();

            if(AdressLibrary.TryGetValue(name , out AdressBook book))
            {
                book.AdressBookOperation();
                return;
            }

            Console.WriteLine("Adress book not found");
        }

        public void SearchByCity()
        {
            Console.WriteLine("Enter the city name to search by city and if there is no city saved as provided by you then output will be empty .");
            string city = Console.ReadLine();

            foreach(var entry in AdressLibrary)
            {
                AdressBook book = entry.Value;
                foreach(Contacts contact in book.GetAllContacts())
                {
                    if(contact.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(contact.FirstName + " " +  contact.LastName);
                    }
                }

            }
        }

        public void SearchByState()
        {
            Console.WriteLine("Enter the state name to search by state and if there is no state saved as provided by you then output will be empty");
            String state = Console.ReadLine();

            foreach(var entry in AdressLibrary)
            {
                AdressBook book = entry.Value;
                foreach(Contacts contact in book.GetAllContacts())
                {
                    if (contact.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(contact.FirstName + " " + contact.LastName);
                    }
                }
            }
        }

    }
}
