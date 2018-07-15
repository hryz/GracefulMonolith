using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Write.Customers.Entities
{
    public class ContactEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
