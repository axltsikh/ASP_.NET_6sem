using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdLab.Models
{
    [Serializable]
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Contact(string _username,string _phoneNumber)
        {
            Name = _username;
            Phone = _phoneNumber;
        }
        public Contact(int id,string _username, string _phoneNumber)
        {
            ID = id;

            Name = _username;
            Phone = _phoneNumber;
        }
        public Contact()
        {

        }
        public Contact(int ID)
        {
            this.ID = ID;
        }
    }
}