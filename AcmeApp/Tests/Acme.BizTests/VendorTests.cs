using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;
using Xunit;


namespace Acme.Biz.Tests
{
    
    public class VendorTests
    {
        [Fact]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlaceOrderTest()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                                     "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12);

            // Assert
            Assert.Equal(expected.Result, actual.Result);
            Assert.Equal(expected.Message, actual.Message);
        }
        
        [Fact]
        public void PlaceOrder_3Parameters()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                "\r\nDeliver By: " + new DateTime(2019,10,25).ToString("d") +
                "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(2019, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            // Assert
            Assert.Equal(expected.Result, actual.Result);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void PlaceOrder_NullProduct_Exception()
        {
            // Arrange
            var vendor = new Vendor();

            // Act
            //var actual = vendor.PlaceOrder(null, 12);
            void Act() => vendor.PlaceOrder(null, 12);

            // Assert
            // Expected exception
            //Assert
            //Exception ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Throws<ArgumentNullException>((Action)Act);
        }

        [Fact]
        public void PlaceOrder_NoDeliveryDate()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                        "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                        "\r\nInstructions: Deliver to Suite 42");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                                instructions: "Deliver to Suite 42");

            // Assert
            Assert.Equal(expected.Result, actual.Result);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void ToStringTest()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp (1)";

            // Act
            var actual = vendor.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendEmailTest()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.Retrieve();

            var vendors = vendorsCollection.ToList();

                //Console.WriteLine(vendorsCollection.Count);

            var expected = new List<string>()
            {
                "Message sent: Important email for: ABC Corp",
                "Message sent: Important email for: XYZ Inc",
            };

            //Act
            var actual = Vendor.SendEmail(vendorsCollection, "Test Message");

            //Assert
            Assert.Equal(expected, actual);
        }

        public void SendEmailTestArray()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendors = vendorRepository.RetrieveArray();

            var expected = new List<string>()
            {
                "Message sent: Important email for: ABC Corp",
                "Message sent: Important email for: XYZ Inc",
            };

            //Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendEmailTestDictionary()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            //var vendors = vendorRepository.RetrieveWithKeys();
            var vendorsCollection = vendorRepository.Retrieve();
            var vendors = vendorsCollection.ToDictionary(v => v.CompanyName);

            var expected = new List<string>()
            {
                "Message sent: Important email for: ABC Corp",
                "Message sent: Important email for: XYZ Inc",
            };

            //Act
            var actual = Vendor.SendEmail(vendors.Values, "Test Message");

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}