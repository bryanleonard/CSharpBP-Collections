using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {

        private List<Vendor> vendors;

        public IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>()
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" },
                new Vendor() { VendorId = 3, CompanyName = "EFG Ltd", Email = "efg@efg.com" },
                new Vendor() { VendorId = 4, CompanyName = "HIJ AG", Email = "hij@hig.com" },
                new Vendor() { VendorId = 5, CompanyName = "Marvel Toys", Email = "info@mtoys.com" },
                new Vendor() { VendorId = 6, CompanyName = "Toy Blocks Inc", Email = "hello@toyblocks.com"} ,
                new Vendor() { VendorId = 7, CompanyName = "Home Stuffs", Email = "info@homestuffs.com" },
                new Vendor() { VendorId = 8, CompanyName = "Car Toys", Email = "vroom@cartoys.com" },
                new Vendor() { VendorId = 9, CompanyName = "Fun Toys", Email = "youknowwhatimean@funtoys.com" },
                new Vendor() { VendorId = 10, CompanyName = "LMNO Products", Email = "hello@lmnoproducts.com" },
                new Vendor() { VendorId = 68, CompanyName = "Mojo Babies Inc", Email = "sixtyeight@mojobabies.com" },
                new Vendor() { VendorId = 42, CompanyName = "Answer To Everything Corp", Email = "hello@bringatowel.com" },
            };
             
            return vendors;
        }




        public ICollection<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });
            }

            return vendors;
        }

        //vendorIterator isn't called until the first element is iterated over.
        //Called "deferred execution"
        // yield return will jump things back to the outer loop (of the calling code)
        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            //get the data from the database
            this.Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor Id: {vendor.VendorId}");
                yield return vendor;
            }
        }

        public List<Vendor> RetrieveList()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();
                vendors.Add(new Vendor(){ VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com"});
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });
            }

            return vendors;
        }

        public Vendor[] RetrieveArray()
        {
            var vendors = new Vendor[2]
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "XYZ Inc",  Email = "xyz@xyz.com" }
            };

            return vendors;
        }

        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>()
            {
                {"ABC Corp", new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" }},
                {"XYZ Inc",  new Vendor() { VendorId = 2, CompanyName = "XYZ Inc",  Email = "xyz@xyz.com" }}
            };

#region GetDictionaryValue
            if (vendors.ContainsKey("Bryan"))
            {
                // would check for value to not throw error but looks up the item twice.
            }

            //or tryget, it's more efficient
            Vendor vendy;
            if (vendors.TryGetValue("XYV", out vendy))
            {
                //write the value or whatever.
                Console.WriteLine(vendy);
            }
            #endregion

#region IterateDictionary

            foreach (var id in vendors.Keys) // or vendors.Values
            {
                Console.WriteLine(id);
            }

            foreach (var el in vendors)
            {
                var vendor = el.Value;
                var key = el.Key;  
            }
#endregion
            return vendors;
        }

        //public int RetrieveValue(string sql, int defaultValue)
        //{
        //    // Call the DB to retrieve a value
        //    // if no value returned, return the default
        //    int value = defaultValue;
        //    return value;
        //}

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            T value = defaultValue;
            return value;
        }



        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }
    }
}
