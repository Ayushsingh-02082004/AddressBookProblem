using AddressManagemement.services;

namespace AddressManagemement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            

            AdressBook book = new AdressBook();
            book.deleteContact(firstName );
            book.DisplayContact();

        }


    }
}
