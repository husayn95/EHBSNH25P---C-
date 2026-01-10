using CManager.Presentation.ConsoleApp.Models;
using CManager.Presentation.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Controllers
{

    
    public class CustomerController
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        //startar menyloopen
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Skapa kund");
                Console.WriteLine("2. Visa kunder");
                Console.WriteLine("3. Visa specifik kund");
                Console.WriteLine("4. Ta bort kund");
                Console.WriteLine("0. Avsluta");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateCustomer(); break;
                    case "2": ShowCustomers(); break;
                    case "3": ShowCustomer(); break;
                    case "4": DeleteCustomer(); break;
                    case "0": return;
                }
            }
        }

        //skapar en ny kund från inmatning
        private void CreateCustomer()
        {
            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine()!;
            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine()!;
            Console.Write("E-post: ");
            var email = Console.ReadLine()!;
            Console.Write("Telefon: ");
            var phone = Console.ReadLine()!;
            Console.Write("Gatuadress: ");
            var street = Console.ReadLine()!;
            Console.Write("Postnummer: ");
            var postalCode = Console.ReadLine()!;
            Console.Write("Ort: ");
            var city = Console.ReadLine()!;

            _service.CreateCustomer(firstName, lastName, email, phone,
                new Address { Street = street, PostalCode = postalCode, City = city });

            Console.WriteLine("Kund skapad!");
            Console.ReadKey();
        }

        //visar alla kunder
        private void ShowCustomers()
        {
            foreach (var customer in _service.GetAll())
                Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email}");

            Console.ReadKey();
        }

        //visar information om en specifik kund
        private void ShowCustomer()
        {
            Console.Write("Ange e-post: ");
            var email = Console.ReadLine()!;
            var customer = _service.GetByEmail(email);

            if (customer == null)
            {
                Console.WriteLine("Kund hittades inte.");
            }
            else
            {
                Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"ID: {customer.Id}");
                Console.WriteLine($"Telefon: {customer.Phone}");
                Console.WriteLine($"E-post: {customer.Email}");
                Console.WriteLine($"Adress: {customer.Address.Street}, {customer.Address.PostalCode} {customer.Address.City}");
            }

            Console.ReadKey();
        }

        //tar bort en kund baserat på epost
        private void DeleteCustomer()
        {
            Console.Write("Ange e-post: ");
            var email = Console.ReadLine()!;

            if (_service.DeleteByEmail(email))
                Console.WriteLine("Kunden har blivit borttagen.");
            else
                Console.WriteLine("Kund hittades inte.");

            Console.ReadKey();
        }
    }


}
