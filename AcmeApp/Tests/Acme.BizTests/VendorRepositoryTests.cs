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
        public void RetrieveTestImproved()
        {
            //Arrange
            var repo = new VendorRepository();

            var expected = new List<Vendor>();
            expected 
                .Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected
                .Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });

            //Act
            var actual = repo.Retrieve();

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