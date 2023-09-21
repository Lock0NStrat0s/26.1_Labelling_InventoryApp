namespace _26._1_Labelling_Inventory;

public class Program
{
    static void Main(string[] args)
    {
        Pack pack = new Pack(10, 20, 30);

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Pack Items: {pack.CurrentItems}/{pack.TotalItems}");
            Console.WriteLine($"Pack Weight: {pack.CurrentWeight}/{pack.MaxWeight}");
            Console.WriteLine($"Pack Volume: {pack.CurrentVolume} / {pack.MaxVolume}");
            Console.WriteLine(pack.ToString());
            Console.WriteLine("1 - Arrow");
            Console.WriteLine("2 - Bow");
            Console.WriteLine("3 - Rope");
            Console.WriteLine("4 - Water");
            Console.WriteLine("5 - Food");
            Console.WriteLine("6 - Sword");
            Console.Write("Select item to add to pack: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            InventoryItem newItem = choice switch
            {
                1 => new Arrow(),
                2 => new Bow(),
                3 => new Rope(),
                4 => new Water(),
                5 => new Food(),
                6 => new Sword()
            };

            if (!pack.Add(newItem))
                Console.WriteLine("Could not add this to the pack.");
        }
    }
}

public class Pack
{
    private List<InventoryItem> items = new List<InventoryItem>();

    public int TotalItems { get; private set; }
    public double MaxWeight { get; private set; }
    public double MaxVolume { get; private set; }

    public int CurrentItems { get; set; }
    public double CurrentWeight { get; set; }
    public double CurrentVolume { get; set; }

    public Pack(int totalItems, double maxWeight, double maxVolume)
    {
        TotalItems = totalItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }

    public bool Add(InventoryItem item)
    {
        if (CurrentItems >= TotalItems) return false;
        if ((CurrentVolume + item.Volume) > MaxVolume) return false;
        if ((CurrentWeight + item.Weight) > MaxWeight) return false;

        items.Add(item);

        CurrentItems++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;

        return true;
    }

    public override string ToString()
    {
        string contents = "This pack contains ";
        if (items.Count == 0)
        {
            contents += "nothing.";
        }
        else
        {
            foreach (InventoryItem item in items)
            {
                contents += item.ToString() + ", ";
            }
        }


        return contents;
    }
}

public class InventoryItem
{
    public double Weight { get; set; }
    public double Volume { get; set; }

    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05)
    {
    }
    public override string ToString()
    {
        return "Arrow";
    }
}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4)
    {
    }
    public override string ToString()
    {
        return "Bow";
    }
}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5)
    {
    }
    public override string ToString()
    {
        return "Rope";
    }
}

public class Water : InventoryItem
{
    public Water() : base(2, 3)
    {
    }
    public override string ToString()
    {
        return "Water";
    }
}

public class Food : InventoryItem
{
    public Food() : base(1, 0.5)
    {
    }
    public override string ToString()
    {
        return "Food";
    }
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3)
    {
    }
    public override string ToString()
    {
        return "Sword";
    }
}