using AddressManagemement.Entity;
using AddressManagemement.services;
using AddressManagemement.ExceptionHandle;
using NUnit.Framework;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TestCasesAdressBook
{
    [TestFixture]
    public class AdressBookTest
    {
        private AdressBook adressbook;
        [SetUp]
        public void Init()
        {
            adressbook = new AdressBook();

        }

        [Test]
        public void AdressBook_shouldbecreated()
        {
            Assert.That(adressbook, Is.Not.Null);
        }

        [Test]
        public void AddContact_ShouldAddContact()
        {
            // Arrange
            var contact = new Contacts(
                "Ayush",
                "Singh",
                "Street 1",
                "Bangalore",
                "Karnataka",
                "560001",
                "9999999999",
                "ayush@gmail.com"
            );

            // Act
            adressbook.AddContact(contact);

            Assert.That(adressbook.GetAllContacts().Count, Is.EqualTo(1));

        }

        [Test]
        public void deletecontact_shouldDeletecontact()
        {
            var contact = new Contacts(
                "Ayush",
                "Singh",
                "A",
                "City",
                "State",
                "560001",
                "9876543210",     
                "ayush@gmail.com" 
            );
            adressbook.AddContact(contact);

            bool result = adressbook.DeleteContact("Ayush");

            Assert.That(result, Is.True);
            Assert.That(adressbook.GetAllContacts().Count, Is.EqualTo(0));
        }

        [Test]
        public void DupliacteFirstName_ShouldNotAdd()
        {
            var contact1 = new Contacts(
                "Ayush", "Singh", "A", "City", "State",
                "560001", "9876543210", "ayush@gmail.com"
            );
            var contact2 = new Contacts(
                "Ayush", "Singh", "B", "City2", "State2",
                "560001", "9876543210", "ayush@gmail.com"
            );

            adressbook.AddContact(contact1);
            adressbook.AddContact(contact2);

            Assert.That(adressbook.GetAllContacts().Count,Is .EqualTo(1));
        }

        [Test]
        public void AddNullContact_ShouldNotCrash()
        {
            adressbook.AddContact(null);

            Assert.That(adressbook.GetAllContacts().Count, Is.EqualTo(0));
        }

        [Test]
        public void ContactInvalid_PhoneNumber_ShouldThorw_Exception()
        {
            Assert.Throws<PhoneNumberException>(() =>
            {
                new Contacts(
                    "Ayush", "Singh", "A", "City", "State",
                    "560001", "123", "ayush@gmail.com"
                );
            });
        }

        [Test]
        public void SortByName_shouldReturn_AlphabeticalOrder()
        {
            adressbook.AddContact(new Contacts("Rahul", "Verma", "A", "Pune", "MH", "411001", "9876543210", "r@gmail.com"));
            adressbook.AddContact(new Contacts("Ayush", "Singh", "A", "Delhi", "DL", "110001", "9876543211", "a@gmail.com"));
            adressbook.AddContact(new Contacts("Amit", "Agarwal", "A", "Delhi", "DL", "110002", "9876543212", "b@gmail.com"));

            var result = adressbook.GetContactsSortedByName();


            Assert.That(result[1].FirstName, Is.EqualTo("Ayush"));
            Assert.That(result[1].LastName, Is.EqualTo("Singh"));

            Assert.That(result[0].FirstName, Is.EqualTo("Amit"));
            Assert.That(result[0].LastName, Is.EqualTo("Agarwal"));

            Assert.That(result[2].FirstName, Is.EqualTo("Rahul"));
        }
    }
}
