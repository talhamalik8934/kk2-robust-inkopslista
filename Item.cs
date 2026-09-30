// One item on the shopping list.
class Item
{
    // Variable Name has properties get and set.
    // get and set allows the user to read and modify the name and price.
    public string Name { get; set; }
    public int Price { get; set; }

    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }


    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
