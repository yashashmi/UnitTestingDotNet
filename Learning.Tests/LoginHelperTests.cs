using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learning.Tests
{
    [TestClass]
    public class LoginHelperTests
    {
        string validPassword_;
        string validUser_;

        [TestInitialize]
        public void OneTimeSetup()
        {
            validPassword_ = "Password12";
            validUser_ = "David";
        }

        [TestMethod]
        public void ShouldReturnSuccessMessageOnSuccessfulLogin()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser(validUser_, validPassword_);

            var loginHelper = new LoginHelper(userCreator);
            var result = loginHelper.Login(validUser_, validPassword_);

            Assert.AreEqual("Login Successful", result);
        }

        [TestMethod]
        public void ShouldReturnFailureMessageOnInvalidUserName()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser(validUser_, validPassword_);

            var loginHelper = new LoginHelper(userCreator);
            var result = loginHelper.Login("Scooby", validPassword_);

            Assert.AreEqual("Login Failed", result);
        }

        [TestMethod]
        public void ShouldReturnFailureMessageOnIncorrectPassword()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser(validUser_, validPassword_);

            var loginHelper = new LoginHelper(userCreator);
            var result = loginHelper.Login(validUser_, "WrongPassword");

            Assert.AreEqual("Login Failed", result);
        }

        [TestMethod]
        public void ShouldThrowArgumentExceptionWhenUserNameIsEmpty()
        {

            var loginHelper = new LoginHelper(new UserCreator());

            Assert.ThrowsException<ArgumentException>(() => loginHelper.Login(string.Empty, validPassword_));
        }

        [TestMethod]
        public void ShouldThrowArgumentExceptionWhenPasswordIsEmpty()
        {

            var loginHelper = new LoginHelper(new UserCreator());

            Assert.ThrowsException<ArgumentException>(() => loginHelper.Login(validUser_, string.Empty));
        }
    }
}