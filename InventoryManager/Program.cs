class Inventory
{

    // Properties
    public Dictionary<string, int> Products { get; set; } = new Dictionary<string, int>();

    // Methods
    public void Add(string name, int quantity)
    {
        if (Products.ContainsKey(name))
        {
            Products[name] += quantity;
        }
        else
        {
            Products[name] = quantity;
        }
    }

    public void Remove(string name, int quantity)
    {
        if (Products.ContainsKey(name))
        {
            Products[name] -= quantity;
            if (Products[name] <= 0)
            {
                Products.Remove(name);
            }
        }
        else
        {
            Console.WriteLine("That product does not exist!");
            throw new KeyNotFoundException();
        }
    }

    public int GetStock(string name)
    {
        return Products.GetValueOrDefault(name);
    }

    public string MostStocked()
    {

        return Products.MaxBy(p => p.Value).Key;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Inventory inv = new Inventory();
        inv.Add("Apples", 50);
        inv.Add("Bananas", 70);
        inv.Add("Apples", 10);
        foreach (int count in inv.Products.Values)
        {
            Console.WriteLine(count);
        }
        // inv.Remove("Banana", 30);
        foreach (int count in inv.Products.Values)
        {
            Console.WriteLine(count);
        }
        Console.WriteLine($"Apple stock is currently: {inv.GetStock("Apples")}");
        Console.WriteLine($"Item with most stock is: {inv.MostStocked()}");
    }
}
