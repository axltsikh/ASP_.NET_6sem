using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{
    [Serializable]
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Contact(string _username, string _phoneNumber)
        {
            Name = _username;
            Phone = _phoneNumber;
        }
        public Contact()
        {

        }
        public override string ToString()
        {
            return $"ID: {ID}; Name: {Name}; Phone: {Phone}";
        }
    }
}
