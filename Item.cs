using System;
//Stores information about an item in the game.
struct Item
{
    //Properties describe the item.
    public string Name { get; set; }
    public int Points { get; set; }

    //Creates an item with a name and point value.
    public Item(string name, int points)
    {
        Name = name;
        Points = points;
    }

    //Displays information about the item.
    public void ShowItem()
    {
        Console.WriteLine($"{Name} is worth {Points} points.");
    }
}