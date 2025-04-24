using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager<string> manager = new ItemManager<string>();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException
        manager.AddItem("Apple");
        manager.AddItem("Banana");
        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");
        Console.WriteLine();
        Console.WriteLine("Item of Manager after remove Apple:");
    
        manager.PrintAllItems();

        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        // TODO: Implement this part three.
        Console.WriteLine();
        Console.WriteLine("Item of Fruit Manager:");
        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();
        fruitManager.AddItem(new Fruit("Apple", "Red"));
        fruitManager.AddItem(new Fruit("Banana", "Yellow"));
        fruitManager.AddItem(new Fruit("Grapes", "Purple"));
        fruitManager.PrintAllItems();

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

interface IItemManager<T>
{
    void AddItem(T item);
    void RemoveItem(T item);
    void PrintAllItems();
    void ClearAllItems();
}

public class Fruit
{
    public string Name { get; set; }
    public string Color { get; set; }

    public Fruit(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Name} ({Color})";
    }
}


public class ItemManager<T>
{
    private List<T> items;

    public ItemManager()
    {
        items = new List<T>();
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void RemoveItem(T item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items = [];
    }
}