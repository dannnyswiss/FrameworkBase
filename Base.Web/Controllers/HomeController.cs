
using Base.BoundedContextCustomers;
using System;
using System.Linq;
using System.Web.Mvc;
using Base.Classes;

namespace Base.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public void CheckHowToUseUnitOfWork()
        {
            using (var repo = new CustomerRepository(new UnitOfWorkCustomer()))
            {
                var i = 1;
                foreach (var customer in repo.AllIncluding(c => c.Orders).Where(c => c.Orders.Any()).ToList())
                {
                    Console.WriteLine("{0}, {1} ( {2} ) Order Count = {3}", customer.FirstName, customer.LastName, i, customer.Orders.Count);
                    i += 1;
                }

            }
        }

    }
}