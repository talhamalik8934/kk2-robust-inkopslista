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

        if ( name=="" || name== null )
        {
            // Throws ArgumentException if the name is empty.
            throw new ArgumentException("Namnet får inte vara tomt");
        }

        if (price<0)
        {
            // Throws ArgumentOutOfRangeExcrption if the price is negative.
            throw new ArgumentOutOfRangeException("Priset för inte vara negativt");
        }
    }


    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
