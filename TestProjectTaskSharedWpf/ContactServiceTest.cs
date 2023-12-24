
using TaskSharedWpf.Models;
using TaskSharedWpf.Services;
namespace TestProjectTaskSharedWpf;

public class ContactServiceTest
{


    [Fact]

    public void AddToListShould_AddOneContactToContactList_AndReturntTrue()
    {
        //Arrange

        Contact contact = new Contact { FirstName = "Isra", LastName = "Morales", Address = "Väg 56", Phone = "0786543456", Email = "IsraM@gear.se" };

        ContactService contactService = new ContactService();



        //Act

        bool result = contactService.AddContact(contact);
        //Assert

        Assert.NotEqual(Guid.Empty, contact.guid);
        Assert.True(result);

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
}
