using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLibrary
{
    public class ContactRepository : IPhoneDictionary,IDisposable
    {
        ContactContext db;
        public ContactRepository(DbContextOptions<ContactContext> options)
        {
            this.db = new ContactContext(options);
        }
        public void Add(Contact contact)
        {
            db.contacts.Add(contact);
            db.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            try
            {
                db.contacts.Remove(db.contacts.Find(contact.ID));
                db.SaveChanges();
            }
            catch
            {
             
            }
        }

        public void DeleteByID(int id)
        {
            db.contacts.Remove(db.contacts.Find(id));
            db.SaveChanges();
        }

        public void Dispose()
        {
            
        }

        public Contact GetBook(int id)
        {
            foreach(Contact a in db.contacts)
            {
                if (a.ID == id)
                    return a;
            }
            return new Contact();
        }

        public IEnumerable<Contact> GetBookList()
        {
            return db.contacts;
        }

        public Contact GetByID(int id)
        {
            return db.contacts.Find(id);
        }

        public void Update(Contact contact)
        {

            Contact s = db.contacts.Find(contact.ID);
            s.Name = contact.Name;
            s.Phone = contact.Phone;
            db.SaveChanges();
        }

    }
}
