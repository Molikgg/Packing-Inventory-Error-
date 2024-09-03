Console.WriteLine("Add item");
Pack pack = new Pack(10, 15, 15);
for (int i = 0; i < pack.TotalItem; i++)
{

    string Useritem = Console.ReadLine()!;
   InventoryItem itemList = Useritem.ToLower() switch
    {
        "arrow" => new Arrow(),
        "bow" => new Bow(),
        "rope"=> new Rope(),
        "water" => new Water(),
        "food" => new Food(),
        "sword" => new Sword()
    };
    InventoryItem[] inventoryItems = new InventoryItem[pack.TotalItem];
    inventoryItems[i] = itemList;
    Display();
    if (pack.Packing(inventoryItems) == false) { break; }

    void Display()
    {
        Console.WriteLine($"""
        Current Count: {i}/ Max Weight: {pack.TotalItem}
        Current Weight:{itemList.Weight}/ Max Weight: {pack.MaxWeight}
        Current Volume:{itemList.Volume}/ Max Weight: {pack.MaxVolume}
        """);
    }
}

public class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }
    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

class Pack
{
    public int TotalItem { get; set; } = 0;
    public float MaxWeight { get; set; }
    public float MaxVolume { get; set; }
    public bool Packing(InventoryItem[] item)
    {
        foreach (InventoryItem currentItem in item)
        {
            float weight = 0;
            float volume = 0;
            int count = 0;
            weight = weight + currentItem.Weight;
            volume = volume + currentItem.Volume;
            count = count + item.GetLength(0);
            if (weight > MaxWeight) return false;
            if (volume > MaxVolume) return false;
            if (count > TotalItem) return false;
        }
        return true;
    }
    public Pack(int totalItem, float maxWeight, float maxVolume)
    {
        TotalItem = totalItem;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }
}
public class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
public class Bow : InventoryItem { public Bow() : base(1, 4) { } }
public class Rope : InventoryItem { public Rope() : base(1, 1.5f) { } }
public class Water : InventoryItem { public Water() : base(2, 3) { } }
public class Food : InventoryItem { public Food() : base(1, 0.5f) { } }
public class Sword : InventoryItem { public Sword() : base(5, 3) { } }
