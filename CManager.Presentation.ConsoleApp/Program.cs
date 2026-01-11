using CManager.Presentation.ConsoleApp.Controllers;
using CManager.Presentation.ConsoleApp.Repositories;
using CManager.Presentation.ConsoleApp.Services;

var repository = new CustomerRepository();
var service = new CustomerService(repository);
var controller = new CustomerController(service);

//startar applikationen
controller.Run();
