using CManager.Presentation.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CManager.Presentation.ConsoleApp.Repositories
{
    //repository ansvarar endast för filhantering.
    public class CustomerRepository : ICustomerRepository
    {
        private const string FilePath = "customers.json";

        //läser in kunder från json fil
        public List<Customer> Load()
        {
            //om filen inte finns, returnera en tom lista
            if (!File.Exists(FilePath))
                return new List<Customer>();

            //läs all text från filen
            var json = File.ReadAllText(FilePath);

            //konvertera json till en lista med kunder
            return JsonSerializer.Deserialize<List<Customer>>(json) ?? new();
        }

        //sparar kundlistan till json fil
        public void Save(List<Customer> customers)
        {
            //konverterar listan till json format
            var json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
            {
                WriteIndented = true // Gör filen lättläst
            });

            // kriver json till fil
            File.WriteAllText(FilePath, json);
        }
    }

    
}
