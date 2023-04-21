using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RepositoryLibrary
{
    public class ContactRepository : IPhoneDictionary,IDisposable
    {
        private ContactContext db = new ContactContext();
        public void Add(Contact contact)
        {
            db.contacts.Add(contact);
            db.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                var customer = new Contact { ID = contact.ID };

                db.contacts.Attach(customer);
                db.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            finally
            {
                db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
            }
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

        public void Update(Contact contact)
        {
            Debug.WriteLine(contact.ID);
            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}
