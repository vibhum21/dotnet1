using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Password { get; set; }
        private readonly string role;
        public string Role
        {
            get
            {
                return role;
            }
        }

    }
}
