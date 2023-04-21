using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ThirdLab.Models
{
    public class Phonebook
    {
        int counter = 0;
        public List<Contact> contacts = new List<Contact>();
        public void addContact(Contact contact)
        {
            Load();
            contact.ID = counter;
            contacts.Add(contact);
            Save();
        }
        public void updateContact(Contact contact)
        {
            Debug.WriteLine(contact.ID);
            Load();
            Contact buffer = contacts.Find(item => item.ID == contact.ID);
            buffer.Name = contact.Name;
            buffer.Phone = contact.Phone;
            Save();
        }
        public void deleteContact(Contact contact)
        {
            Debug.WriteLine(contact.ID);
            Load();
            contacts.RemoveAt(contacts.FindIndex(item => item.ID == contact.ID));
            Save();
        }
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter("D:/Univ/.NET/ThirdLab/contacts.json", false))
            {
                sw.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
            }
        }
        public List<Contact> Load()
        {
            contacts = new List<Contact>();
            try
            {
                using (StreamReader sw = new StreamReader("D:/Univ/.NET/ThirdLab/contacts.json"))
                {
                    string buffer = sw.ReadToEnd();
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(buffer);
                }
                if (contacts != null)
                {
                    counter = contacts[contacts.Count - 1].ID + 1;
                }
                else
                {
                    contacts = new List<Contact>();
                }
            }
            catch(System.Exception exc)
            {
                Debug.WriteLine("No file at path");
            }
            return contacts;
        }
    }
}