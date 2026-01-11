using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Models
{
    public class Customer
    {
        //unikt ID för varje kund
        public Guid Id { get; set; }

        //kundens förnamn
        public string FirstName { get; set; } = null!;

        //kundens efternamn
        public string LastName { get; set; } = null!;

        //kundens epostadress 
        public string Email { get; set; } = null!;

        //kundens telefonnummer
        public string Phone { get; set; } = null!;

        //kundens adress 
        public Address Address { get; set; } = null!;
    }

}
