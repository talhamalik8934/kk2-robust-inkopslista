// Holds the items and takes care of loading and saving them.
using System.Security.Cryptography.X509Certificates;

class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;

    private int budgetTak= 600;

    // A construstor that needs an objekt.
    public ShoppingList(string path)
    {
        this.path = path;
    }

    public void Add(Item item)
    {
        int currentTotal= Total();

        // An if-sats that checks if the total price is more then the budget.
        // If the totalprice is more then the budget then it throws an exception.
        if (currentTotal + item.Price > budgetTak)
        {
            throw new InvalidOperationException("Du har överstigit budgettak.");
        }

        items.Add(item);
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        items.RemoveAt(number - 1);
    }

    // Counts the amount of items in the list.
    public int Count
    {
        get {return items.Count; }
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

        
    

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            // To.lower on both sides so lower/uppercase does not matters.
            if (item.Name.ToLower() == name.ToLower())
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        // Tries to save the file and handles any file errors.
        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines));
            Console.WriteLine("Listan är sparad.");
        }
        catch (IOException)
        {
            Console.WriteLine ("Fel: Kunde inte sparas.");
        }

        
    }

    // Reads the file back into the list.
    public void Load()
    {
        // If-stats that checks if the file exists inorder to prevent crash.
        if(!File.Exists(path))
        {
            return;
        }

        string[] lines = File.ReadAllLines(path);
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            items.Add(new Item(parts[1], int.Parse(parts[0])));
        }
    }
}
