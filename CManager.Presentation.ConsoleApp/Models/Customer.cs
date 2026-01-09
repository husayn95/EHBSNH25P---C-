using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Models
{
    // Customer representerar en kund i systemet.
    // Klassen används som en datamodell (Model).
    public class Customer
    {
        // Unikt ID för varje kund
        public Guid Id { get; set; }

        // Kundens förnamn
        public string FirstName { get; set; } = null!;

        // Kundens efternamn
        public string LastName { get; set; } = null!;

        // Kundens e-postadress ( för att identifiera kunden)
        public string Email { get; set; } = null!;

        // kundens telefonnummer
        public string Phone { get; set; } = null!;

        // Kundens adress 
        public Address Address { get; set; } = null!;
    }

}
