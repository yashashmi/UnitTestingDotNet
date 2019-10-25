using NUnit.Framework;

namespace Learning.Tests
{
    [TestFixture]
    public class UserCreatorTests
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
        public void ShouldReturnSuccessMessageOnCreationOfUser()
        {
            var userCreator = new UserCreator();
            var result = userCreator.CreateUser(validUser_, validPassword_);

            Assert.AreEqual("User created successfully", result);
        }

        [Test]
        public void ShouldReturnFailureMessageIfUserNameContainsOtherThanLetters()
        {
            var userCreator = new UserCreator();
            var result = userCreator.CreateUser("David11", validPassword_);

            Assert.AreEqual("User creation failed", result);
        }

        [Test]
        public void UserListShouldNotBeNullEvenIfNoUserCreated()
        {
            var userCreator = new UserCreator();

            Assert.IsNotNull(userCreator.Users);
        }

        [Test]
        public void ShouldIncreaseTheUserCountInListOnUserCreation()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser(validUser_, validPassword_);

            Assert.AreEqual(1, userCreator.Users.Count);
        }

        [Test]
        public void ShouldNotIncreaseTheUserCountInListOnUserCreationFailure()
        {
            var userCreator = new UserCreator();
            userCreator.CreateUser("David1", validPassword_);

            Assert.AreEqual(0, userCreator.Users.Count);
        }

        [Test]
        public void ShouldReturnFailureMessageIfPasswordIsShorterThanSixCharacters()
        {
            var userCreator = new UserCreator();
            var result = userCreator.CreateUser(validUser_, "abc");

            Assert.AreEqual("User creation failed", result);
        }

        [Test]
        public void ShouldReturnFailureMessageIfPasswordDoesNotContainAtLeastOneAlphabet()
        {
            var userCreator = new UserCreator();
            var result = userCreator.CreateUser(validUser_, "1234567");

            Assert.AreEqual("User creation failed", result);
        }

        [Test]
        public void ShouldReturnFailureMessageIfPasswordDoesNotContainAtLeastOneNumber()
        {
            var userCreator = new UserCreator();
            var result = userCreator.CreateUser(validUser_, "abcdefg");

            Assert.AreEqual("User creation failed", result);
        }
    }
}