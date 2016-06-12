using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using eCommerceBOL;
using CustomerBusinessLayer;
namespace SunbeamPuneShoppingWeb.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            Customer cust = new Customer();
            // Retrieve form data using form collection 
            cust.CustomerID = 8;

            cust.FirstName = formCollection["FirstName"];
            cust.LastName = formCollection["LastName"];
            cust.Address = formCollection["Address"];
            cust.Email = formCollection["EmailId"];
            cust.MobileNo = formCollection["MobileNo"];
            cust.RegistrationDate = DateTime.Parse(formCollection["RegistrationDate"].ToString());
            cust.Password = formCollection["Password"];
            
            BusinessLayer employeeBusinessLayer = new BusinessLayer();
           bool status= employeeBusinessLayer.AddCustomer(cust);
           if (status)
               return RedirectToAction("Index");
           else
               return View();
        }
    }
}