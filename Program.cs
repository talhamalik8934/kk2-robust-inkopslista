ShoppingList list = new ShoppingList("items.txt");
list.Load();

while (true)
{

    // A command menu. It gives the user multiple choices.
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara"); 
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    // Stores the user's menu choice.
    int choice;
    
    // Loops untill the user enters a valid number between 1 and 5.
    while(!int.TryParse(Console.ReadLine(), out choice)||choice<1 || choice>5)
    {
        Console.Write("Skriv ett heltal eller välj en siffra från meny.\nVälj: ");
    }


    // These are the choices and what they lead to.
    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine();
        Console.Write("Pris: ");

        int price;

        //  Loops untill the user enters a valid and positiv number.
        while(!int.TryParse(Console.ReadLine(),out price) || price<0)
        {
            Console.Write("Ange ett positiv och heltal.\nPris:");
        }

        list.Add(new Item(name, price)); // This adds the name and the price to the list
    }

    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        
        int number;
        
        //  Loops untill the user enters a valid number which is atleast one and is in the list.
          while(!int.TryParse(Console.ReadLine(),out number)||number<1|| number> list.Count)
        {
            Console.Write("Ange ett nummer som finns i listan.\nNummer:");
        }

        list.RemoveAt(number); 
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
