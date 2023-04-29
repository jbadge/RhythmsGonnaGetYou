using System;

namespace RhythmsGonnaGetYou
{
    public class RLDatabase
    {
        public static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Record Label Database");
            Console.WriteLine("---------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true).Key.ToString();
            Console.Clear();
        }

        // Menus
        public static void Menu()
        {
            WelcomeMessage();

            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Main Menu\n\n1. View the database\n2. Manage the database\n3. Quit the database");

                switch (menuInput)
                {
                    case 1:
                        ViewMenu();
                        break;
                    case 2:
                        ManageMenu();
                        break;
                    case 3:
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option.");
                        DialogueRefresher();
                        break;
                }
            }
        }

        public static void ViewMenu()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("View Menu\n\n1. View Bands\n2. View Albums\n3. Back to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        ViewBandsMenu();
                        break;
                    case 2:
                        ViewAlbumsMenu();
                        break;
                    case 3:
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option.");
                        DialogueRefresher();
                        break;
                }
            }
        }

        public static void ViewBandsMenu()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("View Bands Menu\n\n1. View all bands\n2. View all bands that are signed\n3. View all bands that are unsigned\n4. Return to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        // View all the bands
                        Band.ViewAllBands();
                        DialogueRefresher();
                        break;
                    case 2:
                        // View all bands that are signed
                        Band.ViewSignedBands();
                        DialogueRefresher();
                        break;
                    case 3:
                        // View all bands that are not signed
                        Band.ViewUnsignedBands();
                        DialogueRefresher();
                        break;
                    case 4:
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option.");
                        DialogueRefresher();
                        break;
                }
            }
        }

        public static void ViewAlbumsMenu()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("View Menu\n\n1. View Albums by Band Search\n2. View Albums by Release Date\n3. Back to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        // Prompt for a band name and view all their albums
                        Album.ViewAllAlbumsByBand();
                        DialogueRefresher();
                        break;
                    case 2:
                        // View all albums by...(currently only) release date
                        Album.ViewAlbumsBy();
                        DialogueRefresher();
                        break;
                    case 3:
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option.");
                        DialogueRefresher();
                        break;
                }
            }
        }

        public static void ManageMenu()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Management Menu\n\n1. Manage Bands\n2. Manage Albums\n3. Back to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        ManageBandsMenu();
                        break;
                    case 2:
                        ManageAlbumsMenu();
                        break;
                    case 3:
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option.");
                        DialogueRefresher();
                        break;
                }
            }
        }

        public static void ManageBandsMenu()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Manage Bands\n\n1. Add a new band\n2. Add an album for a band\n3. Sign a band\n4. Let a band go\n5. Back to the main menu");

                switch (menuInput)
                {
                    case 1:
                        // Add a new band
                        Band.AddBand();
                        break;
                    case 2:
                        // Add an album for a band
                        Album.AddAlbum();
                        break;
                    case 3:
                        // Resign a band (update isSigned to true)
                        Band.ReSignBand();
                        break;
                    case 4:
                        // Let a band go (update isSigned to false)
                        Band.DropBand();
                        break;
                    case 5:
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option.");
                        DialogueRefresher();
                        break;
                }
            }
        }

        public static void ManageAlbumsMenu()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Manage Albums\n\n1. Add an album for a band\n2. Add a song to an album\n3. Back to the main menu");

                switch (menuInput)
                {
                    case 1:
                        // Add an album for a band
                        Album.AddAlbum();
                        break;
                    case 2:
                        // Add a song to an album
                        Song.AddSong();
                        break;
                    case 3:
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option.");
                        DialogueRefresher();
                        break;
                }
            }
        }

        // Helper Functions
        public static int PromptForInt(string prompt)
        {
            var inputWasInteger = false;
            int inputAsInteger = 0;

            while (!inputWasInteger)
            {
                var userInput = PromptForString(prompt);
                var isThisGoodInput = int.TryParse(userInput, out inputAsInteger);

                if (isThisGoodInput == true)
                {
                    inputWasInteger = true;
                }
                else
                {
                    Console.WriteLine("This is not a valid number. Please try again");
                    DialogueRefresher();
                }
            }
            return inputAsInteger;
        }

        public static bool PromptForBool(string prompt)
        {
            var inputIsValid = false;
            var response = true;

            while (!inputIsValid)
            {
                var userInput = PromptForChar(prompt);
                if (userInput == "Y")
                {
                    inputIsValid = true;
                    response = true;
                }
                else if (userInput == "N")
                {
                    inputIsValid = true;
                    response = false;
                }
                else
                {
                    Console.WriteLine("This is not a valid option. Please try again");
                    DialogueRefresher();
                }
            }
            return response;
        }

        public static string PromptForChar(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadKey(true).Key.ToString().ToUpper();
            Console.Clear();
            return userInput;
        }

        public static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        public static void DialogueRefresher()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true).Key.ToString();
            Console.Clear();
        }

        public void Debug(int num, bool flag = false)
        {
            Console.WriteLine($"Debug {num}");
            if (flag == true)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true).Key.ToString();
            }
        }

    }
}