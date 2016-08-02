using Acme.Common;
using static Acme.Common.LoggingService; //for using static class and its methods
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance created.");
            //this.ProductVendor = new Vendor(); //second usage scenario but not for three (lazy loading)
        }

        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("Product instance has a name: " +
                                ProductName);
        }
        #endregion

        #region Properties
        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }


        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private string productName;        

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //Related objects second case: always
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get {
                if(productVendor == null)
                {
                    productVendor = new Vendor(); //third scenario lazy loading
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        #endregion

        public string SayHello()
        {
            //Related objects first case: One method
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product instance ;)");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product",
                            this.ProductName, "sales@abc.com");

            var result = LoggingService.LogAction("saying hello");
            return "Hello " + ProductName +
                " (" + ProductId + "): " +
                Description +
                " Available on: " +
                AvailabilityDate?.ToShortDateString();
        }

        public decimal CalculateQuantityOnHand()
        {
            var quantity = 0;
            #region Calculate the number in inventory
            #endregion
            return quantity;
        }
    }
}
