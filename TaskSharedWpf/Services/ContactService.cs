



using Newtonsoft.Json;
using System.Diagnostics;
using TaskSharedWpf.Interfaces;
using TaskSharedWpf.Models;

namespace TaskSharedWpf.Services;

public class ContactService 
{

    private readonly FileService _fileService = new FileService();
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
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);

                var json = JsonConvert.SerializeObject(contact, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented });

                var result = _fileService.SaveContentToFile(_filePath, json);

            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

    }

    public IEnumerable<Contact> GetContactsFromList()
    {

        
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content, new JsonSerializerSettings{ TypeNameHandling = TypeNameHandling.Objects })!;
              
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _contacts;


        
    }

    //public Contact GetContactFromList(Contact contact)
    //{

    //   return contact;

     
    //}


    public void Update(Contact contact)
    {
        var contactItem = _contacts.FirstOrDefault(x => x.Id == contact.Id);
        if(contactItem != null)
        {
            contactItem = contact;
        }
    }
    public void Remove(Contact contact)
    {
       

        var contactItem = _contacts.FirstOrDefault(x => x.Id == contact.Id);
        if (contactItem != null)
        {
            _contacts.Remove(contactItem);
        }

    }


}
