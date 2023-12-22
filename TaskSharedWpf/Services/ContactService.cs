



using Newtonsoft.Json;
using System.Diagnostics;
using TaskSharedWpf.Interfaces;
using TaskSharedWpf.Models;

namespace TaskSharedWpf.Services;

public class ContactService : IContactService
{

    private readonly IFileService _fileService = new FileService();
    private List<Contact> _contacts = [];
    private readonly string _filePath = @"C:\Users\User\source\repos\TaskSharedWpf";

    /// <summary>
    /// Add A contact to a contact list
    /// </summary>
    /// <param name="contact">a contact of type IContact</param>
    /// <returns>return true if successful or false is it fails or contact already exist</returns>
    /// 

    public bool AddContact(Contact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);

                var json = JsonConvert.SerializeObject(contact, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects} );

                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }

    public IEnumerable<Contact> GetContactFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }


        return null!;
    }

    public Contact GetContactFromList(Contact contact)
    {


        try
        {
            GetContactFromList();

            var _contact = _contacts.FirstOrDefault();
            return _contact ??= null!;

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

      
        return null!;
    }
}
