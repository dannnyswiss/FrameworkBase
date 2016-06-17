using Base.Classes;
using Base.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;

namespace Base.Test
{
    [TestClass]
    public class TestContext
    {
        [TestMethod]
        public void CanInsertObjectIntoDatabase()
        {
            using (var context = new SalesContext())
            {
                context.Customers.Add(new Customer
                {
                    FirstName = "Dan",
                    LastName = "Swiss"
                });
                context.SaveChanges();
            }
            using (var context = new SalesContext())
            {
                Assert.IsTrue(context.Customers.FirstOrDefault().LastName == "Swiss");
            }

        }

        [TestMethod]
        public void CanRetrieveCustomerReferenceData()
        {
            using (var context = new ReturnsContext())
            {
                Assert.IsTrue(context.Customers.FirstOrDefault().FullName == "Dan Swiss");
            }
        }

        [TestMethod]
        public void ReturnsContextHasMoreThanThreeEntitiesInModel()
        {
            using (var context = new SalesContext())
            {
                var oc = (context as IObjectContextAdapter).ObjectContext;
                foreach (var entity in oc.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace).ToList())
                {
                    Debug.WriteLine(entity.FullName);
                }
                Assert.IsTrue(oc.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace).Count > 3);
            }
        }

        [TestMethod]
        public void CanNavigateFromOneContextToAnotherThatReferencesTheSameTableThroughdifferentContexts()
        {
            int idOne;
            string nameOne;
            using (var context = new ReturnsContext())
            {
                var c = context.Customers.FirstOrDefault();
                idOne = c.Id;
            }
            using (var context = new SalesContext())
            {
                var customer = context.Customers.Find(idOne);
                context.Entry(customer).Reference(c => c.FirstName).Load();
                nameOne = customer.FirstName;
                customer.FirstName = "1" + nameOne;
                context.SaveChanges();
            }
            using (var context = new ReturnsContext())
            {
                Assert.AreEqual("1" + nameOne, context.Customers
                    .Where(c => c.Id == idOne)
                    .Select(c => c.FirstName)
                    .FirstOrDefault());
            }
        }

        [TestMethod]
        public void CanPassFromCustomerServiceToSalesAndAddAnOrder()
        {
            Customer customer;
            int orderCount;
            using (var context = new CustomerServiceContext()) { customer = context.Customers.FirstOrDefault(); }
            using (var context = new SalesContext())
            {
                //context.Customers.Attach(customer); 
                orderCount = context.Orders.Where(o => o.CustomerId == customer.Id).Count();
                //var newOrder = new Order { OrderDate = DateTime.Now, DueDate = DateTime.Now.AddDays(7), ModifiedDate = DateTime.Now };
                //newOrder.LineItems.Add(new LineItem { OrderQty = 1, ProductId = 6, UnitPrice = 200 });
                //customer.Orders.Add(newOrder);
                //context.SaveChanges();
            }
            using (var context = new SalesContext())
            {
                Assert.IsTrue(orderCount + 1 == context.Orders.Where(o => o.CustomerId == customer.Id).Count());
            }
        }
    }
}
