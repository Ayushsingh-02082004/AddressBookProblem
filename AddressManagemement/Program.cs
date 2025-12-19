using AddressManagemement.services;

namespace AddressManagemement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookSystem system = new AddressBookSystem();
            system.AdressLibraryOperation();
        }
    }
}
