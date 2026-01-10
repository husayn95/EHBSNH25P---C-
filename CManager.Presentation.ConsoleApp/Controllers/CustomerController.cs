using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Controllers
{

    // Controller ansvarar för användarens interaktion via konsolen
    public class CustomerController
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

  
}
