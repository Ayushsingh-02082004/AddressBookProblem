using AddressManagemement.Entity;

namespace AddressManagemement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

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

            Contacts contact = new Contacts(
                firstName,
                lastName,
                address,
                city,
                state,
                zip,
                phone,
                email
            );

            AdressBook book = new AdressBook();
            book.addContact(contact);
            book.DisplayContact();

        }


    }
}
