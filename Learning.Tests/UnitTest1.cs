using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learning.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            //Arrange
            Customer1 cust = new Customer1();
            cust.UserName = "Pradeep";

            //Act
            string message = cust.GetWelcomeMessage();

            //Assert
            Assert.AreEqual("Welcome Pradeep", message);
        }































        [TestMethod]
        public void ShouldReturnTheValidWelcomeMessage()
        {
            var customer = new Customer1();
            customer.UserName = "Priya";
            var message = customer.GetWelcomeMessage();

            if (message != "Welcome Priya")
            {
                throw new Exception("Test Failed");
            }
        }

        [TestMethod]
        public void AssertAreSame()
        {
            var obj1 = new Customer1();
            var obj2 = obj1;

            Assert.AreSame(obj1, obj2);
        }

        [TestMethod]
        public void AssertNotSame()
        {
            var obj1 = new Customer1();
            var obj2 = new Customer1();

            Assert.AreNotSame(obj1, obj2);
        }

        [TestMethod]
        public void AssertIsTrue()
        {
            var ch = '1';

            Assert.IsTrue(char.IsDigit(ch));
        }

        [TestMethod]
        public void AssertIsFalse()
        {
            var num1 = 20;
            var num2 = 30;
            Assert.IsFalse(num1 == num2);
        }

        [TestMethod]
        public void AssertAreEqualDecimal()
        {
            var num1 = 20.45d;
            var result = Math.Round(num1 / 3, 3, MidpointRounding.AwayFromZero);

            Assert.AreEqual(result, 6.815d, .01);
        }
    }
}
