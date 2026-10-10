using System;
using System.IO;

//Handles saving and loading game progress.
class SaveManager
{
    // File where the game saves player information.
    static string filePath = "savegame.txt";

    //Writes the player's information to a file.
    public static void SaveGame(Player player)
    {
        // Store player information in seperate lines.
        string[] data =
        {
            player.Name,
            player.Energy.ToString(),
            player.Score.ToString(),
            player.HasKey.ToString()
        };
        // Write the information to the save file.
        File.WriteAllLines(filePath, data);

        Console.WriteLine("\nGame saved successfully!");
    }
    
    // Reads the saved information from a file.
    public static Player? LoadGame()
    {
        // Check whether a save file exists.
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nNo saved game found.");
            return null;
        }

        //Read all the lines from the file.
        string[] data = File.ReadAllLines(filePath);

        // Make sure the file has the expected data.
        if (data.Length != 4 ||
            !int.TryParse(data[1], out int energy) ||
            !int.TryParse(data[2], out int score) ||
            !bool.TryParse(data[3], out bool hasKey))
        {
            Console.WriteLine("\nSave file is invalid.");
            return null;
        }

        //Create a player using the saved name.
        Player player = new Player(data[0]);

        // Restore the saved information.
        player.Energy = energy;
        player.Score = score;
        player.HasKey = hasKey;

        Console.WriteLine("\nGame loaded successfully!");

        return player;
    }
}