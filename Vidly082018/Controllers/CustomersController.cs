using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly082018.Models;
using Vidly082018.ViewModels;


namespace Vidly082018.Controllers
{
    public class CustomersController : Controller
    {
        //DbContext defined in the Model Class
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //_context is a disposeable object...proper way is to call the Dispose method of the Base Controller Class
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            //var customers = GetCustomers();           
            //var customers = _context.Customers.ToList();
            //Eagerly loading the MembershipType table as well
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult New()
        {
            // Action to Load New Customer
            // Only needs MembershipTypes
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModelNewCustomer = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes

            };
            return View("CustomerForm",viewModelNewCustomer);
        }

        public ActionResult Edit(int id)
        {
            // id -> is set as property in the View -> Index
            // Get Customer based of the id 
            // Compose and Return the viewModel ( customer and membershipTypes)

            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            if (customer == null)
                return HttpNotFound();

            // Both Edit and New Action's are using the same View  -> CustomerForm 
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // 3 MAIN STEPS for Server Side Validation
            // 1. Setup  Data Annotations for the Object Properties
            // 2. Check the ModelState and design the control flow
            // 3. Add Validation PlaceHolders in the View ( in this case its in CustomerForm View)
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer =customer,
                    MembershipTypes= _context.MembershipTypes.ToList()  
                };
                return View("CustomerForm",viewModel);
            }

            // Identify New Customer , Insert or Update
            // id -> is set as a hidden field in the View -> CustomerForm 
            if (customer.id == 0)
            {
                //Add New Customer 
                _context.Customers.Add(customer);
            }
            else
            {
                //Update An Existing Customer
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            // ADD try catch to identify the Entity Framework Errors
            _context.SaveChanges();


            // RedirectToAction -> Is used to redirect the navigation to an existing View
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index","Customers");
        }
        
        public ActionResult Details(int id)
        {
            // var customer = GetCustomers().SingleOrDefault(c => c.id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{ id=1,Name="Sashi"},
                new Customer{ id=2,Name="Medha"},
                new Customer{ id=3,Name="Meha"}
            };
        }


    }
}