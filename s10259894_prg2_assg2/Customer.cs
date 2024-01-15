using s10259894_prg2_assg2;
using System;
using System.Xml.Linq;

public class Customer
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private int memberId;
    public int MemberId
    {
        get { return memberId; }
        set { memberId = value; }
    }

    private DateTime dob;
    public DateTime Dob
    {
        get { return dob; }
        set { dob = value; }
    }

    private Order currentOrder = new Order();
    public Order CurrentOrder
    {
        get { return currentOrder; }
        set { currentOrder = value; }
    }
    private List<Order> orderHistory = new List<Order>();
    public List<Order> OrderHistory
    {
        get { return orderHistory; }
        set { orderHistory = value; }
    }

    private PointCard rewards;
    public PointCard Rewards
    {
        get { return rewards;}
        set { rewards = value; }
    }

    public Customer() { }

    public Customer(string name, int memberid, DateTime dob)
    {
        Name = name;
        MemberId = memberid;
        Dob = dob;
    }


    public override string ToString()
    {
        // Custom implementation for converting the object to a string
        return $"Customer: {Name}, Member ID: {MemberId}, Date of Birth: {Dob}";
    }
}
