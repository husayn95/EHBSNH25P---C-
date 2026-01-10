using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Models
{
    public class Address
    {
        //gatuadress
        public string Street { get; set; } = null!;

        //postnummer
        public string PostalCode { get; set; } = null!;

        //stad
        public string City { get; set; } = null!;
    }
}
