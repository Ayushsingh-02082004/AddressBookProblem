using AddressManagemement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagemement.Interface
{
    public interface IAdressbook
    {
        void AddContact();

        void DeleteContact(String firstname);

        void EditContact(String firstname);

        void DisplayContact();


    }
}
