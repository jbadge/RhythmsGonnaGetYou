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
        public static void Menu(RecordLabelDatabaseContext context)
        {
            WelcomeMessage();

            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Main Menu\n\n1. View the database\n2. Manage the database\n3. Quit the database");

                switch (menuInput)
                {
                    case 1:
                        ViewMenu(context);
                        break;
                    case 2:
                        ManageMenu(context);
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

        public static void ViewMenu(RecordLabelDatabaseContext context)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("View Menu\n\n1. View Bands\n2. View Albums\n3. Back to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        ViewBandsMenu(context);
                        break;
                    case 2:
                        ViewAlbumsMenu(context);
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

        public static void ViewBandsMenu(RecordLabelDatabaseContext context)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("View Bands Menu\n\n1. View all bands\n2. View all bands that are signed\n3. View all bands that are unsigned\n4. Return to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        // View all the bands
                        Band.ViewAllBands(context);
                        DialogueRefresher();
                        break;
                    case 2:
                        // View all bands that are signed
                        Band.ViewSignedBands(context);
                        DialogueRefresher();
                        break;
                    case 3:
                        // View all bands that are not signed
                        Band.ViewUnsignedBands(context);
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

        public static void ViewAlbumsMenu(RecordLabelDatabaseContext context)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("View Menu\n\n1. View Albums by Band Search\n2. View Albums by Release Date\n3. Back to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        // Prompt for a band name and view all their albums
                        Album.ViewAllAlbumsByBand(context);
                        DialogueRefresher();
                        break;
                    case 2:
                        // View all albums by...(currently only) release date
                        Album.ViewAlbumsBy(context);
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

        public static void ManageMenu(RecordLabelDatabaseContext context)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Management Menu\n\n1. Manage Bands\n2. Manage Albums\n3. Back to the Main Menu");

                switch (menuInput)
                {
                    case 1:
                        ManageBandsMenu(context);
                        break;
                    case 2:
                        ManageAlbumsMenu(context);
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

        public static void ManageBandsMenu(RecordLabelDatabaseContext context)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Manage Bands\n\n1. Add a new band\n2. Add an album for a band\n3. Re-sign a band\n4. Let a band go\n5. Back to the main menu");

                switch (menuInput)
                {
                    case 1:
                        // Add a new band
                        Band.AddBand(context);
                        break;
                    case 2:
                        // Add an album for a band
                        Album.AddAlbum(context);
                        break;
                    case 3:
                        // Resign a band (update isSigned to true)
                        Band.ReSignBand(context);
                        break;
                    case 4:
                        // Let a band go (update isSigned to false)
                        Band.DropBand(context);
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

        public static void ManageAlbumsMenu(RecordLabelDatabaseContext context)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var menuInput = HelperFunctions.PromptForInt("Manage Albums\n\n1. Add an album for a band\n2. Add a song to an album\n3. Back to the main menu");

                switch (menuInput)
                {
                    case 1:
                        // Add an album for a band
                        Album.AddAlbum(context);
                        break;
                    case 2:
                        // Add a song to an album
                        Song.AddSong(context);
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

    }
}