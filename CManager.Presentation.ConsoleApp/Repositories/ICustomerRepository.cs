using CManager.Presentation.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Repositories
{
    //interface som definierar CustomerRepository måste kunna göra.
    public interface ICustomerRepository
    {
        //hämtar kunder från lagring till fil
        List<Customer> Load();

        //sparar kunder till lagring till fil
        void Save(List<Customer> customers);
    }

}
