namespace Domain.Customer
{
    public class Contact
    {
        public Contact(
            string title, 
            string firstName, 
            string middleName, 
            string lastName)
        {
            Title = title;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public string Title { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
    }
}