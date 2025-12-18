using AddressManagemement.Entity;

namespace AddressManagemement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            

            AdressBook book = new AdressBook();
            book.editContact(firstName);
            book.DisplayContact();

        }


    }
}
