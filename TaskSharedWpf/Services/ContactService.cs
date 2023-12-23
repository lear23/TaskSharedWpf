



using Newtonsoft.Json;
using System.Diagnostics;
using TaskSharedWpf.Interfaces;
using TaskSharedWpf.Models;

namespace TaskSharedWpf.Services;

public class ContactService 
{

    private readonly IFileService _fileService = new FileService();
    private List<Contact> _contacts = [];
    private readonly string _filePath = @"C:\Users\User\source\repos\TaskSharedWpf";

    public Contact currentContact { get; set; } = null!;

    /// <summary>
    /// Add A contact to a contact list
    /// </summary>
    /// <param name="contact">a contact of type IContact</param>
    /// <returns>return true if successful or false is it fails or contact already exist</returns>
    /// 

    public void AddContact(Contact contact)
    {


        _contacts.Add(contact);
      

    }

    public IEnumerable<Contact> GetContactsFromList()
    {

        return _contacts;
      
    }

    //public Contact GetContactFromList(Contact contact)
    //{

    //   return contact;

     
    //}


    public void Update(Contact contact)
    {
        var contactItem = _contacts.FirstOrDefault(x => x.Email == contact.Email);
        if(contactItem != null)
        {
            contactItem = contact;
        }
    }
    public void Remove(Contact contact)
    {
        var contactItem = _contacts.FirstOrDefault(x => x.Email == contact.Email);
        if(contactItem != null)
        {
            _contacts.Remove(contactItem);
        }
    }


}
