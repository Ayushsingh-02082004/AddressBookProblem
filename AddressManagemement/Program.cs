using AddressManagemement.Interface;
using AddressManagemement.services;

namespace AddressManagemement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AdressBook adress = new AdressBook();
            //adress.AdressBookOperation();

            IAddressBookDataSource source = new DatabaseDataSource();

            AdressBook system = new AdressBook(source);
            system.AdressBookOperation();
        }
    }
}
