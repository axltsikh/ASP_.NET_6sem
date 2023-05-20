using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{

    public class jsonContext : IPhoneDictionary
    {
        int counter = 0;
        public List<Contact> contacts = new List<Contact>();
        public void Add(Contact contact)
        {
            GetBookList();
            contact.ID = counter;
            contacts.Add(contact);
            Save();
        }

        public void Delete(Contact contact)
        {
            Debug.WriteLine(contact.ID);
            GetBookList();
            contacts.RemoveAt(contacts.FindIndex(item => item.ID == contact.ID));
            Save();
        }

        public Contact GetBook(int id)
        {
            foreach (Contact a in contacts)
            {
                if (a.ID == id)
                    return a;
            }
            return new Contact();
        }

        public IEnumerable<Contact> GetBookList()
        {
            contacts = new List<Contact>();
            //try
            //{
            //    using (StreamReader sw = new StreamReader("D:/Univ/.NET/SixthLab/contacts.json"))
            //    {
            //        string buffer = sw.ReadToEnd();
            //        contacts = JsonConvert.DeserializeObject<List<Contact>>(buffer);
            //    }
            //    if (contacts != null)
            //    {
            //        counter = contacts[contacts.Count - 1].ID + 1;
            //    }
            //    else
            //    {
            //        contacts = new List<Contact>();
            //    }
            //}
            //catch (System.Exception exc)
            //{
            //    Debug.WriteLine("No file at path");
            //}
            return contacts;
        }

        public void Update(Contact contact)
        {
            Debug.WriteLine(contact.ID);
            GetBookList();
            Contact buffer = contacts.Find(item => item.ID == contact.ID);
            buffer.Name = contact.Name;
            buffer.Phone = contact.Phone;
            Save();
        }
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter("D:/Univ/.NET/SixthLab/contacts.json", false))
            {
                sw.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
            }
        }

        public void DeleteByID(int id)
        {
            
        }

        public void GetByID(int id)
        {
           
        }

        Contact IPhoneDictionary.GetByID(int id)
        {
            return new Contact();
        }
    }
}
