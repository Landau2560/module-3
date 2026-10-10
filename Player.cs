using System;


//Stores information about the player.
class Player
{
    //Properties keep track of player information.
    public string Name { get; set; }
    public int Energy { get; set; }
    public int Score { get; set; }
    public bool HasKey { get; set; }


    //Sets the players starting information
    public Player(string name)
    {
        Name = name;
        Energy = 100;
        Score = 0;
        HasKey = false;
    }

    //Displays the player's current information.
    public void ShowStatus()
    {
        Console.WriteLine($"\nName: {Name}");
        Console.WriteLine($"Energy: {Energy}");
        Console.WriteLine($"Score: {Score}");
        Console.WriteLine($"Golden Key: {HasKey}");
    }
}