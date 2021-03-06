﻿using Acme.Common;
using static Acme.Common.LoggingService;
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
        //version1
        //public Product()
        //{
        //    //Shitty way
        //    //var colorOptions = new string[4];
        //    //colorOptions[0] = "Red";
        //    //colorOptions[1] = "Blue";
        //    //colorOptions[2] = "Green";
        //    //colorOptions[3] = "Yellow";

        //    //Collection initializer 🤘🏻
        //    //OR var colorOptions = new string[4] { "Red", "Blue", "Green", "Yellow" };
        //    //OR string[] colorOptions = new string[4] { "Red", "Blue", "Green", "Yellow" };
        //    string[] colorOptions = { "Red", "Blue", "Green", "Yellow" };

        //    Console.WriteLine(colorOptions);
        //}

        public Product()
        {
            //var colorOptions = new List<string>();
            //colorOptions.Add("Red");
            //colorOptions.Add("Blue");
            //colorOptions.Add("Green");
            //colorOptions.Add("Yellow");
            var colorOptions = new List<string> {"Red", "Blue", "Green", "Yellow"};
            colorOptions.Insert(2, "Purple");

            var states = new Dictionary<string, string>
            {
                {"OH", "Ohio"},
                {"CA", "California"},
                {"HI", "Hawaii"},
                {"ND", "North Dakota"},
                {"NY", "New York"}
            };
            //states.Add("NY", "New York");

        }

        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        //public decimal CalculateSuggestedPrice(decimal markupPercent) =>
        //     this.Cost + (this.Cost * markupPercent / 100);

        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";
            if (markupPercent <= 0m)
            {
                message = "Invalid markup percentage";
            }
            else if (markupPercent < 10)
            {
                message = "Below recommended markup percentage";
            }

            var value = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResult<decimal>(value, message);
            return operationResult;
        }
            

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
