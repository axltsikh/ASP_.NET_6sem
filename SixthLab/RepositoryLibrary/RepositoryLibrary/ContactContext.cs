using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{
    class ContactContext : DbContext
    {
        public ContactContext() : base("DefaultConnection") { }
        public DbSet<Contact> contacts { get; set; }
    }
}
