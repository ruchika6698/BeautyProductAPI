using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer
{
    public class UserDetails
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOnCreation { get; set; } = DateTime.Now;

    }
}
