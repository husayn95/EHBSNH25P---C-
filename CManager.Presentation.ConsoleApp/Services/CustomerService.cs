using CManager.Presentation.ConsoleApp.Models;
using CManager.Presentation.ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CManager.Presentation.ConsoleApp.Services
{
    
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly List<Customer> _customers;

        //konstruktor som tar emot repository
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;

            //laddar kunder från fil när programmet startar
            _customers = _repository.Load();
        }

        //skapar en ny kund och sparar den
        public Customer CreateCustomer(string firstName, string lastName, string email, string phone, Address address)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(), //skapar unikt ID
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address
            };

            _customers.Add(customer);        //sägg till kund i listan
            _repository.Save(_customers);    //spara till fil

            return customer;
        }

        //returnerar alla kunder
        public List<Customer> GetAll()
        {
            return _customers;
        }

        //returnerar en kund baserat på epostadress
        public Customer? GetByEmail(string email)
        {
            return _customers.FirstOrDefault(c =>
                c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        //tar bort en kund baserat på epostadress
        public bool DeleteByEmail(string email)
        {
            var customer = GetByEmail(email);

            if (customer == null)
                return false;

            _customers.Remove(customer);
            _repository.Save(_customers);

            return true;
        }
    }

}
