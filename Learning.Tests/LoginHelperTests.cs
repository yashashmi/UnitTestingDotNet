using System;
using NUnit.Framework;

namespace Learning.Tests
{
    [TestFixture]
    public class LoginHelperTests
    {
        string validPassword_;
        string validUser_;

        [SetUp]
        public void OneTimeSetup()
        {
            validPassword_ = "Password12";
            validUser_ = "David";
        }

        [Test]
        public void ShouldReturnSuccessMessageOnSuccessfulLogin()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser(validUser_, validPassword_);

            var loginHelper = new LoginHelper(userCreator);
            var result = loginHelper.Login(validUser_, validPassword_);

            Assert.AreEqual("Login Successful", result);
        }

        [Test]
        public void ShouldReturnFailureMessageOnInvalidUserName()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser(validUser_, validPassword_);

            var loginHelper = new LoginHelper(userCreator);
            var result = loginHelper.Login("Scooby", validPassword_);

            Assert.AreEqual("Login Failed", result);
        }

        [Test]
        public void ShouldReturnFailureMessageOnIncorrectPassword()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser(validUser_, validPassword_);

            var loginHelper = new LoginHelper(userCreator);
            var result = loginHelper.Login(validUser_, "WrongPassword");

            Assert.AreEqual("Login Failed", result);
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenUserNameIsEmpty()
        {

            var loginHelper = new LoginHelper(new UserCreator());

            Assert.Throws<ArgumentException>(() => loginHelper.Login(string.Empty, validPassword_));
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenPasswordIsEmpty()
        {

            var loginHelper = new LoginHelper(new UserCreator());

            Assert.Throws<ArgumentException>(() => loginHelper.Login(validUser_, string.Empty));
        }
    }
}