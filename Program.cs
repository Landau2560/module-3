using System;

class Program
{
    static void Main()
    {
        // Displays the title of the game
        Console.WriteLine("Welcome To The Enchanted Forest!");
        Console.WriteLine("------------------------------------");

        //Ask the player to eneter a name and store it
        Console.WriteLine("Enter your name: ");
        string playerName = Console.ReadLine() ?? "Explorer";

        //Create a Player object using the player's name
        Player player = new Player(playerName);

        // Create items using Item structure.
        Item goldenKey = new Item("Golden Key", 20);
        Item magicCrystal = new Item("Magic Crystal", 15);

        bool playing = true;

        // Introduce the player to the adventure
        Console.WriteLine($"\nWelcome, {playerName}!");
        Console.WriteLine("Your mission is to find the Golden Treasure!");

        //Keep the game playing while the player is playing and still has energy.
        while (playing && player.Energy > 0)
        {
            // Call the function to display the menu
            ShowMenu();

            // Get the player's menu selection
            Console.Write("Choose 1-9: ");
            string choice = Console.ReadLine() ?? "";

            // Different actions happens depending on what option the player choses.

            if (choice == "1")
            {
                // Exploring costs energy but earns points
                Console.WriteLine("\nYou discover a beautiful waterfall.");

                //Subtract energy and add to the score.
                player.Energy -= 10;
                player.Score += 10;

                Console.WriteLine("You earned 10 points!");
            }
            else if (choice == "2")
            {
                // Check is the player already found the key.
                if (!player.HasKey)
                {
                    Console.WriteLine("\nYou found a magical golden key!");

                    //Mark the key as collected.
                    player.HasKey = true;

                    // Add the item's points to the score.
                    player.Score += goldenKey.Points;

                    // Display information about the item.
                    goldenKey.ShowItem();
                }
                else
                {
                    Console.WriteLine("\nYou already have the golden key!");
                }
            }
            else if (choice == "3")
            {
                // Call the method from the Player class.
                player.ShowStatus();
            }
            else if (choice == "4")
            {
                // Allow the player to regain energy.
                //Math.min prevents energy from going above the maximum value of 100.
                player.Energy = Math.Min(100, player.Energy + 20);

                Console.WriteLine("\nYou rested and regained energy.");
            }
            else if (choice == "5")
            {
                //Check whether the player has the key.
                if (player.HasKey)
                {
                    // The player wins if they have the key
                    Console.WriteLine("\nCongradulations!");
                    Console.WriteLine("You unlocked the Golden Treasure!");
                    Console.WriteLine("YOU WIN!");

                    //Give bonus points for winning
                    player.Score += 50;

                    // Stop the game loop
                    playing = false;
                }
                else
                {
                    // The chest cannot open without the key
                    Console.WriteLine("\nThe chest is locked.");
                    Console.WriteLine("Find the Golden Key first.");
                }
            }
            else if (choice == "6")
            {
                // Find the magical crystal.
                Console.WriteLine("\nYou discovered a magical crystal!");

                // Add points using the Item structure.
                player.Score += magicCrystal.Points;

                // Display information about the crystal.
                magicCrystal.ShowItem();
            }
            else if (choice == "7")
            {
                // Save the player's current progress.
                SaveManager.SaveGame(player);
            }
            else if (choice == "8")
            {
                //Load the player's previously saved progress.
                Player? loadedPlayer = SaveManager.LoadGame();

                // Only replace the player if loading worked.
                if (loadedPlayer != null)
                {
                    player = loadedPlayer;
                }
            }
            else if (choice == "9")
            {
                // Exit the game.
                playing = false;
                Console.WriteLine("\nThanks for playing!");
            }
            else
            {
                // Handle an invalid menu selection
                Console.WriteLine("\nInvalid choice. Try again.");
            }

        }
        // Check whether the player ran out of energy.
        if (player.Energy <= 0)
        {
            Console.WriteLine("\nYou ran out of energy!");
            Console.WriteLine("Your adventure has ended.");
        }

        // Display the player's final score.
        Console.WriteLine($"Final Score: {player.Score}");
    }
    static void ShowMenu()
    {
        // Display the main menu.
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Explore the forest");
            Console.WriteLine("2. Search for the magical key");
            Console.WriteLine("3. Check your status");
            Console.WriteLine("4. Rest");
            Console.WriteLine("5. Open the treasure chest");
            Console.WriteLine("6. Look for the magical crystal");
            Console.WriteLine("7. Save Game");
            Console.WriteLine("8. Load Game");
            Console.WriteLine("9. Quit");
    }
}