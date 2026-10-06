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

        // The while-loop stops the user directly if the name is empty. 
        // It does not requires the user to write in price. Which the try- catch would do.
        // The ArgumentException is still kept as a backup.
        while(name=="")
        {
            Console.WriteLine("Namnet får inte vara tomt. Försök igen!");
            Console.Write("Namn: ");
            name= Console.ReadLine();
        }
        Console.Write("Pris: ");

        int price;

        //  Loops untill the user enters a valid and positiv number.
        while(!int.TryParse(Console.ReadLine(),out price) || price<0)
        {
            Console.Write("Ange ett positiv och heltal.\nPris:");
        }

        try
        {
            list.Add(new Item(name, price)); // This adds the name and the price to the list
        }
        // Catches InvalidOperationException if the total price is more then the budget.
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fel: {ex.Message} Försök igen");
        }
        // Catches ArgumentOutOfRangeException if the price is negative.
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Fel: {ex.Message} Försök igen");
        }
        // Catches ArgumentException if the name is empty.
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Fel: {ex.Message} Försök igen");
        }
        
        
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
