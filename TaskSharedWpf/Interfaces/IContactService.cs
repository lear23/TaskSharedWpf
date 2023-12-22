

using TaskSharedWpf.Models;

namespace TaskSharedWpf.Interfaces;

public interface IContactService
{
    bool AddContact(Contact contact);
    IEnumerable<Contact> GetContactFromList();

    Contact GetContactFromList(Contact contact);

}
