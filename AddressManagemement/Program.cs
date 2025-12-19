using AddressManagemement.services;

namespace AddressManagemement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdressBook system = new AdressBook();
            system.AdressBookOperation();
        }
    }
}
