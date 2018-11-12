using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.Biz.Tests
{
    public class VendorRepositoryTests
    {

        [Fact]
        public void RetrieveAllTest_QuerySyntax()
        {
            //Arrange
            var repo = new VendorRepository();
            var expected  = new List<Vendor>()
            {
                new Vendor() { VendorId = 8, CompanyName = "Car Toys", Email = "vroom@cartoys.com" },
                new Vendor() { VendorId = 9, CompanyName = "Fun Toys", Email = "youknowwhatimean@funtoys.com" },
                new Vendor() { VendorId = 5, CompanyName = "Marvel Toys", Email = "info@mtoys.com" },
                new Vendor() { VendorId = 6, CompanyName = "Toy Blocks Inc", Email = "hello@toyblocks.com"} ,
            };

            //Act
            var vendors = repo.RetrieveAll();
            //could pass lambdas straight in, too (which is preferred)
            var vendorQuery = vendors.Where(FilterCompanies)
                .OrderBy(OrderCompaniesByName);

            //Assert
            Assert.Equal(expected, vendorQuery.ToList()); //query not executed until ToList()
        }

        private bool FilterCompanies(Vendor v) => v.CompanyName.Contains("Toy");

        private string OrderCompaniesByName(Vendor v) => v.CompanyName;


        [Fact]
        public void RetrieveAllTest_MethodSyntax()
        {
            //Arrange
            var repo = new VendorRepository();
            var expected = new List<Vendor>()
            {

                new Vendor() { VendorId = 5, CompanyName = "Marvel Toys", Email = "info@mtoys.com" },
                new Vendor() { VendorId = 6, CompanyName = "Toy Blocks Inc", Email = "hello@toyblocks.com"} ,
                new Vendor() { VendorId = 8, CompanyName = "Car Toys", Email = "vroom@cartoys.com" },
                new Vendor() { VendorId = 9, CompanyName = "Fun Toys", Email = "youknowwhatimean@funtoys.com" },
            };

            //Act
            var vendors = repo.RetrieveAll();
            var vendorQuery = from v in vendors
                where v.CompanyName.Contains("Toy")
                select v; //query not executed until   (via ToList())

            //Assert
            Assert.Equal(expected, vendorQuery.ToList());
        }



        [Fact]
        public void RetrieveTestGoodest()
        {
            //Arrange
            var repo = new VendorRepository();

            var expected = new List<Vendor>();
            expected
                .Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected
                .Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });

            //Act
            var actual = repo.Retrieve();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveWithIterator()
        {
            //Arrange
            var repo = new VendorRepository();
            var expected = new List<Vendor>
            {
                new Vendor() {VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com"},
                new Vendor() {VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"}
            };

            //Act
            //vendorIterator isn't called until the first element is iterated over.
            //Called "deferred execution"
            // yield return jumps us back to the outer (foreach) loop
            var vendorIterator = repo.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }

            var actual = vendorIterator.ToList();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveTestImproved()
        {
            //Arrange
            var repo = new VendorRepository();

            var expected = new List<Vendor>();
            expected 
                .Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected
                .Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });

            //Act
            var actual = repo.RetrieveList();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveTest()
        {
            //Arrange
            var repo = new VendorRepository();
            var expected = 2;

            //Act
            var actual = repo.Retrieve();

            //Assert
            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void RetrieveTest_Whatever()
        {
            //Arrange
            var repo = new VendorRepository();
            var expected = "ABC Corp";

            //Act
            var actual = repo.Retrieve(1).CompanyName;

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void RetrieveValueTest()
        {
            // Arrange
            var repo = new VendorRepository();
            var expected = 42;

            // Act
            var actual = repo.RetrieveValue<int>("Select...", 42);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveValueTest_String()
        {
            // Arrange
            var repo = new VendorRepository();
            var expected = "Bryan";

            // Act
            var actual = repo.RetrieveValue<string>("Select...", "Bryan");

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetrieveWithKeysTest()
        {
            //Arrange
            var repo = new VendorRepository();
            var expected = new Dictionary<string, Vendor>()
            {
                {"ABC Corp", new Vendor() {VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com"}},
                {"XYZ Inc", new Vendor() {VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"}}
            };
            
            //Act
            var actual = repo.RetrieveWithKeys();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}