



using Newtonsoft.Json;
using System.Diagnostics;

using TaskSharedWpf.Models;

namespace TaskSharedWpf.Services;

public class ContactService 
{

    private readonly FileService _fileService = new FileService();
    private List<Contact> _contacts = [];
    private readonly string _filePath = @"C:\Users\User\source\repos\TaskSharedWpf\WpfAppTask\contacts.json"; 

    public Contact currentContact { get; set; } = null!;

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

                var json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented });

                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
               
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;

    }

    public IEnumerable<Contact> GetContactsFromList()
    {

        
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content, new JsonSerializerSettings{ TypeNameHandling = TypeNameHandling.All }) ?? [];
              
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _contacts;


        
    }

    public bool ContactExists(string email)
    {
        return _contacts.Any(x => x.Email == email);
    }


    public bool Update(Contact contact)
    {
        try
        {
            if (_contacts.Any(x=> x.Email == contact.Email))
            {
                _contacts.Remove(contact);
                _contacts.Add(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });

                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactService-UpdateContact:: " + ex.Message);
        }
        return false;
    }



    public void Remove(Contact contact)
    {
        try
        {
            var contactItem = _contacts.FirstOrDefault(x => x.Email == contact.Email);

            if (contactItem != null)
            {
                _contacts.Remove(contactItem);

                // Serialize the updated contacts list
                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });

                // Save the updated list to the file
                var result = _fileService.SaveContentToFile(_filePath, json);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactService-RemoveContact:: " + ex.Message);
        }
    }


}

