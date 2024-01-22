using s10259894_prg2_assg2;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Order> orders = CreateOrders();
        List<Customer> customers = CreateCustomer();
        List<IceCream> IceCreamList = new List<IceCream>();
        Queue<Order> Queue = new Queue<Order>();
        DisplayCustomers();
    }
    static void DisplayCustomers()
    {
        string[] data = File.ReadAllLines("customers.csv");
        string[] header = data[0].Split(',');
        Console.WriteLine("{0,10}, {1,10}, {2,10}" , header[0], header[1], header[2]);
        for (int i = 1; i < data.Length; i++)
        {
            string[] data2 = data[i].Split(",");
            Console.WriteLine("{0,10}, {1,10}, {2,10}", data2[0], data2[1], data2[2]);
        }
    }
    static List<Customer> CreateCustomer()
    {
        List<Customer> customers = new List<Customer>();
        string[] data = File.ReadAllLines("customers.csv");
        string[] header = data[0].Split(',');
        for (int i = 1; i < data.Length; i++)
        {
            string[] data2 = data[i].Split(",");
            Customer c = new Customer(data2[0], Convert.ToInt32(data2[1]), Convert.ToDateTime(data2[2]));
            customers.Add(c);
        }
        Console.WriteLine("Customers have been created");
        return customers;
    }
    static List<Order> CreateOrders()
    {
        List<Order> orders = new List<Order>();
        string[] data = File.ReadAllLines("orders.csv");
        string[] header = data[0].Split(',');
        for (int i = 1; i < data.Length; i++)
        {
            string[] data2 = data[i].Split(",");
            Order o = new Order(Convert.ToInt32(data2[0]), Convert.ToDateTime(data2[2]));
            orders.Add(o);
        }
        return orders;
    }
}