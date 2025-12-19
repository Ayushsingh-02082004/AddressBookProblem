using AddressManagemement.services;

namespace AddressManagemement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdressBook book  = new AdressBook();
            bool flag = true;


            while (flag)
            {
                Console.WriteLine("--------------------------AdressBook_____________________________");
                Console.WriteLine("Chose 1 for AddingContact");
                Console.WriteLine("Chose 2 for DeletingContat");
                Console.WriteLine("Chose 3 for EditContact");
                Console.WriteLine("Chose 4 to stop the program");
                Console.WriteLine("Chose 5 for DisplayProgram");
                Console.WriteLine("Choose Option: ");

                String choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        book.AddContact();
                        break;
                    case "2":
                        Console.WriteLine("Enter first name for deleting Contact");
                        book.DeleteContact(Console.ReadLine());
                        break;
                    case "3":
                        Console.WriteLine("Enter first name for editing contact");
                        book.EditContact(Console.ReadLine());
                        break;
                    case "4":
                        book.DisplayContact();
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
    }
}
