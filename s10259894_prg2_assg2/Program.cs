using s10259894_prg2_assg2;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        List<IceCream> IceCreamList = new List<IceCream>();
        Queue<Order> Queue = new Queue<Order>();
        while (true)
        {
            
        }
    }
    static void DisplayCustomers()
    {
        string[] data = File.ReadAllLines("customers.csv");
        string[] header = data[0].Split(',');
    }
}