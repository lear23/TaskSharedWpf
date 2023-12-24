using TaskSharedWpf.Models;
using TaskSharedWpf.Services;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace TestProjectTaskSharedWpf
{
    public class ContactServiceTest
    {
        [Fact]
        public void AddToListShould_AddOneContactToContactList_AndReturnTrue()
        {
            // Arrange
            ContactService contactService = new ContactService();
            Contact contact = new Contact { FirstName = "Isra", LastName = "Morales", Address = "Väg 56", Phone = "0786543456", Email = "IsraM@gear.se" };

            // Act
            bool result = contactService.AddContact(contact);

            // Assert
            Assert.NotEqual(Guid.Empty, contact.guid);
            Assert.True(result);

            // Act again with the same contact
            bool result1 = contactService.AddContact(contact);

            // Assert
            Assert.False(result1);
        }

        [Fact]
        public void GetContactFromListShould_GetAllContactsInContactList_ThenReturnListOfContact()
        {
            // Arrange
            ContactService contactService = new ContactService();
            Contact contact = new Contact { FirstName = "Isra", LastName = "Morales", Address = "Väg 56", Phone = "0786543456", Email = "IsraM@gear.se" };
            contactService.AddContact(contact);

            // Act
            IEnumerable<Contact> content = contactService.GetContactsFromList();

            // Assert
            Assert.NotNull(content);
            Assert.True(content.Any());
        }

        [Fact]
        public void ContactExists_ShouldReturnTrue_WhenContactExists()
        {
            // Arrange
            var contactService = new ContactService();
            var email = "IsraM@gear.se";
            var contact = new Contact { Email = email };
            contactService.AddContact(contact);

            // Act
            bool result = contactService.ContactExists(email);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ContactExists_ShouldReturnFalse_WhenContactDoesNotExist()
        {
            // Arrange
            var contactService = new ContactService();
            var email = "NonExistentEmail@gear.se";

            // Act
            bool result = contactService.ContactExists(email);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Update_ShouldReturnFalse_WhenContactDoesNotExist()
        {
            // Arrange
            var contactService = new ContactService();
            var nonExistentContact = new Contact { Email = "NonExistentEmail@gear.se" };

            // Act
            bool result = contactService.Update(nonExistentContact);

            // Assert
            Assert.False(result);
        }



        [Fact]
        public void Remove_ShouldRemoveContact_WhenContactExists()
        {
            // Arrange
            var contactService = new ContactService();
            var emailToRemove = "IsraM@gear.se";
            var contactToRemove = new Contact { Email = emailToRemove };

            // Add the contact to remove
            contactService.AddContact(contactToRemove);

            // Act
            contactService.Remove(contactToRemove);

            // Assert
            Assert.False(contactService.ContactExists(emailToRemove));
        }

        [Fact]
        public void Remove_ShouldDoNothing_WhenContactDoesNotExist()
        {
            // Arrange
            var contactService = new ContactService();
            var nonExistentContact = new Contact { Email = "NonExistentEmail@gear.se" };

            // Act
            contactService.Remove(nonExistentContact);

            // Assert
            // No exception should be thrown, and the method should gracefully handle the non-existent contact
        }
    }
}










