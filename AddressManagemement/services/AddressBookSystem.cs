using AddressManagemement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagemement.services
{
    public class AddressBookSystem
    {

        private Dictionary<String , AdressBook> AdressLibrary = new Dictionary<String , AdressBook>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<String, List<Contacts>> CityiDictionary = new Dictionary<string, List<Contacts>>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<String, List<Contacts>> StateDictionary = new Dictionary<string, List<Contacts>>(StringComparer.OrdinalIgnoreCase);

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
                Console.WriteLine("press 6 to view all person in a city");
                Console.WriteLine("press 7 to view all person in a state");
                Console.WriteLine("press 8 to get the count of contact in city");
                Console.WriteLine("press 9 to get the count of contact in state");
                Console.WriteLine("press 10 to Exit from the library");

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
                        ViewPersonByCity();
                        break;
                    case "7":
                        ViewPersonByState();
                        break;
                    case "8":
                        CountByCity();
                        break;
                    case "9":
                        CountByState();
                        break;
                    case "10":
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

        private void BuildCityStateDictionary()
        {
            CityiDictionary.Clear();
            StateDictionary.Clear();

            foreach(var entry in AdressLibrary)
            {
                foreach(Contacts contact in entry.Value.GetAllContacts())
                {
                    //city
                    if (!CityiDictionary.ContainsKey(contact.City))
                    {
                        CityiDictionary[contact.City] = new List<Contacts>();
                    }
                    CityiDictionary[contact.City].Add(contact);

                    //state
                    if (!StateDictionary.ContainsKey(contact.State))
                    {
                        StateDictionary[contact.State] = new List<Contacts>();
                    }
                    StateDictionary[contact.State].Add(contact);
                }
            }
        }

        public void ViewPersonByCity()
        {
            BuildCityStateDictionary();
            Console.WriteLine("Enter City Name : ");
            String city = Console.ReadLine();

            if (CityiDictionary.ContainsKey(city))
            {
                foreach (Contacts contact in CityiDictionary[city])
                {
                    Console.WriteLine(contact.FirstName + " " + contact.LastName);
                }
            }

            else Console.WriteLine($"There is no city of name {city}");
        }

        public void ViewPersonByState()
        {
            BuildCityStateDictionary();
            Console.WriteLine("Enter the State Name : ");

            String state = Console.ReadLine();
            if (StateDictionary.ContainsKey(state))
            {
                foreach (Contacts contact in StateDictionary[state])
                {
                    Console.WriteLine(contact.FirstName + " " + contact.LastName);
                }
            }
            else Console.WriteLine($"There is no state of name {state}");
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

        public void CountByCity()
        {
            BuildCityStateDictionary();
            Console.WriteLine("Enter cityname to get count ");
            String city = Console.ReadLine();

            if (CityiDictionary.ContainsKey(city))
            {
                int Count = CityiDictionary[city].Count;
                Console.WriteLine($"Count of contacts in the city : {city} is : {Count}");
            }

            else Console.WriteLine($"There is no city named {city} .");
        }

        public void CountByState()
        {
            BuildCityStateDictionary();
            Console.WriteLine("Enter the state name to get count");

            String state = Console.ReadLine();

            if (StateDictionary.ContainsKey(state))
            {
                int count = StateDictionary[state].Count;
                Console.WriteLine($"Count of the contact in state : {state} is : {count}");
            }

            else Console.WriteLine($"There is no state named {state}");
        }

    }
}
