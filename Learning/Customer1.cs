namespace Learning
{
    public class Customer1
    {
        public Customer1()
        {
        }

        public string UserName { get; set; }

        public string GetWelcomeMessage()
        {
            return "Welcome" + UserName;
        }
    }
}
