using CManager.Presentation.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Services
{
    public interface ICustomerService
    {
        //skapar en ny kund
        Customer CreateCustomer(string firstName, string lastName, string email, string phone, Address address);

        //sämtar alla kunder
        List<Customer> GetAll();

        //sämtar en specifik kund baserat på e-post
        Customer? GetByEmail(string email);

        //tar bort en kund baserat på e-post
        bool DeleteByEmail(string email);
    }
}
