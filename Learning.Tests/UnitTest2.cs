using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Learning.Tests

{
    
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Test()
        {
            UserCreator2 us = new UserCreator2();
            var result = us.CreateUser();

            Assert.AreEqual("User Created", result);

        }
        
    }

public class UserCreator2
{
    public string CreateUser()
    {
        return "User Created";
    }

    //public bool IsValidUser
}

}