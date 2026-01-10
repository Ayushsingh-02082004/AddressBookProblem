using AddressManagemement.Entity;
using System.Collections.Generic;
using AddressManagemement.services;

namespace AddressManagemement.Interface
{
	public interface IAddressBookDataSource
	{
		void Save(List<Contacts> contacts);
		List<Contacts> Load();
        //void Update(Contacts contact);
        //void Delete(string firstName, string lastName);
    }
}
