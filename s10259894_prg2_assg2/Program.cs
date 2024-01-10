internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
abstract class IceCream
{
    private string option;
    public string Option
    {
        get { return option; }
        set { option = value; }
    }

    private int scoops;
    public int Scoops
    {
        get { return scoops; }
        set { scoops = value; }
    }

    private List<Flavour> flavours = new List<Flavour>();
    public List<Flavour> Flavours
    {
        get { return flavours; }
        set { flavours = value; }
    }

    private List<Topping> toppings = new List<Topping>();
    public List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public IceCream() { }

    public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) 
    { 
        this.option = option;
        this.scoops = scoops;
        this.flavours = flavours;
        this.toppings = toppings;
    }
    public override string ToString()
    {
        return $"Option: {option}, Scoops: {scoops}, Flavours: {flavours}, Toppings: {toppings}";
    }
}

class Flavour
{
    private string type;
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    private bool premium;
    public bool Premium
    {
        get { return premium; }
        set { premium = value; }
    }

    private int quantity;
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Flavour() { }

    public Flavour(string type, bool premium, int quantity) 
    { 
        this.type = type;
        this.premium = premium;
        this.quantity = quantity;
    }

    public override string ToString()
    {
        return $"Flavour type: {Type}, premium: {Premium}, quantity: {Quantity}";
    }
}

class Topping
{
    private string type;
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public Topping() { }

    public Topping(string type)
    {
        Type = type;
    }

    public override string ToString()
    {
        return $"Topping: {Type}";
    }
}