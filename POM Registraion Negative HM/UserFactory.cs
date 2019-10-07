namespace Homework
{
    public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
        {
            return new RegistrationUser
            {
                FirstName = "Joro",
                LastName = "Doev",
                Date = "3",
                Month = "3",
                Year = "1985",
                Address = "Vitoshka Str",
                City = "Sofia",
                State = "Arizona",
                Password = "passss",
                PostCode = "50050",
                Phone = "087654321",
                Alias = "Home"
            };
        }
    }
}
