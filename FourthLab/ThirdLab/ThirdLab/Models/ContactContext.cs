using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ThirdLab.Models
{
    class ContactContext: DbContext
    {
        public ContactContext() : base("ContactContext") { }
        public DbSet<Contact> Contacts { get; set; }

    }
}