using System;

    public class Customer
    {
        // Properties
        public string Name { get; set; }
        public int MemberId { get; set; }
        public DateTime Dob { get; set; }
        public Order CurrentOrder { get; set; }
        public List<Order> OrderHistory { get; set; }
        public PointCard Rewards { get; set; }

        // Constructors
        public Customer()
        {
            // Default constructor
            OrderHistory = new List<Order>();
            Rewards = new PointCard();
        }

        public Customer(string name, int memberId, DateTime dob)
            : this()
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
        }

        // Methods
        public Order MakeOrder()
        {
            // Implementation for making an order
            // You might create a new Order object, update CurrentOrder, and add it to OrderHistory
            Order newOrder = new Order();
            CurrentOrder = newOrder;
            OrderHistory.Add(newOrder);
            return newOrder;
        }

        public bool IsBirthday()
        {
            // Implementation for checking if it's the customer's birthday
            DateTime today = DateTime.Today;
            return Dob.Month == today.Month && Dob.Day == today.Day;
        }

        public override string ToString()
        {
            // Custom implementation for converting the object to a string
            return $"Customer: {Name}, Member ID: {MemberId}, Date of Birth: {Dob.ToShortDateString()}, {Rewards}";
        }
    }
}
