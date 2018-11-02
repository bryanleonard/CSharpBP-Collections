﻿using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;
using Xunit;
using Xunit.Abstractions;

namespace Acme.Biz.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CalculateSuggestedPriceTest()
        {
            // Arrange
            var currentProduct = new Product(1, "Saw", "");
            currentProduct.Cost = 50m;
            //var expected = 55m;
            var expected = new OperationResult<decimal>(55m, "");

            // Act
            var actual = currentProduct.CalculateSuggestedPrice(10m);

            // Assert
            //Assert.Equal(expected, actual);
            Assert.Equal(expected.Result, actual.Result);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "  Steel Hammer  ";

            var expected = "Steel Hammer";

            //Act
            var actual = currentProduct.ProductName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";

            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ProductName_TooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Steel Bladed Hand Saw";

            string expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ProductName_JustRight()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";

            string expected = "Saw";
            string expectedMessage = null;

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }
    }



  
}