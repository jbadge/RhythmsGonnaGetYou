using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    public class HelperFunctions
    {
        static void BandCount()
        {
            var context = new RecordLabelDatabaseContext();
            var bandCount = context.Bands.Count();

            Console.WriteLine($"There are {bandCount} bands!");
        }

        static void BandSearchWithAlbumAndSongs()
        {
            var context = new RecordLabelDatabaseContext();
            var bandsWithAlbumsAndSongs = context.Bands.Include(band => band.Albums).ThenInclude(album => album.Songs);

            // Band search resulting in Albums and Songs on albums (if needed)
            foreach (var band in bandsWithAlbumsAndSongs)
            {
                if (band.Albums == null)
                {
                    Console.WriteLine($"{band.Name} has no albums associated with them in the database.");
                }
                else
                {
                    Console.WriteLine($"{band.Name} has {band.Albums.Count()} in the database, including:.");
                }
                foreach (var album in band.Albums)
                {
                    Console.WriteLine($"{album.Title}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void AlbumSearchWithBand()
        {
            var context = new RecordLabelDatabaseContext();
            var albumsWithBands = context.Albums.Include(album => album.Band);

            // Album search resulting in album title and band name
            foreach (var album in albumsWithBands)
            {
                if (album.Band == null)
                {
                    Console.WriteLine($"There is an album named {album.Title} that has no band associated with it.");
                }
                else
                {
                    Console.WriteLine($"There is a album called {album.Title} by {album.Band.Name}.");
                }
            }
        }

        static void AlbumSearchWithBandAndSongs()
        {
            var context = new RecordLabelDatabaseContext();
            var albumsWithSongsAndBand = context.Albums.Include(album => album.Band).Include(album => album.Songs);

            // Album Search resulting in Band and Songs on album.
            foreach (var album in albumsWithSongsAndBand)
            {
                if (album.Band == null)
                {
                    Console.WriteLine($"There is an album named {album.Title} that has no band associated with it.");
                }
                else
                {
                    Console.WriteLine($"{album.Title} was written by {album.Band.Name}.");
                }

                Console.WriteLine($"{album.Title} contains the songs:");
                foreach (var songs in album.Songs)
                {
                    Console.WriteLine($"{songs.Title}");
                }
                Console.WriteLine();
                Console.WriteLine();

            }
        }

        static void SongSearchWithBandAndAlbum()
        {
            var context = new RecordLabelDatabaseContext();
            var songsWithAlbumsAndBand = context.Songs.Include(song => song.Album).ThenInclude(album => album.Band);

            // Song search resulting in Album and Band
            foreach (var song in songsWithAlbumsAndBand)
            {

                if (song.Album == null)
                {
                    Console.WriteLine($"The song {song.Title} is no band or album associated with this song.");
                }
                else
                {
                    // foreach (var album in songsWithAlbumsAndBand)
                    // {
                    Console.WriteLine($"The song {song.Title} is from the album {song.Album.Title}, by {song.Album.Band.Name}");
                    // }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        static void SongDuration()
        {
            var context = new RecordLabelDatabaseContext();

            foreach (var band in context.Bands)
            {
                Console.WriteLine($"There is a band named {band.Name}.");
            }

            foreach (var song in context.Songs)
            {
                Console.WriteLine($"The duration of this song is {song.Duration} and d2 is {song.d2}");
            }
        }

        // Helper Functions
        public static int PromptForInt(string prompt)
        {
            var inputWasInteger = false;
            int inputAsInteger = 0;

            while (!inputWasInteger)
            {
                // var userInput = Console.ReadKey().KeyChar;
                // var isThisGoodInput = int.TryParse(userInput.ToString(), out inputAsInteger);
                var userInput = PromptForString(prompt);
                var isThisGoodInput = int.TryParse(userInput, out inputAsInteger);

                if (isThisGoodInput == true)
                {
                    inputWasInteger = true;
                }
                else
                {
                    Console.WriteLine("This is not a valid number. Please try again");
                    // DIALOGUE REFRESHER
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true).Key.ToString();
                    Console.Clear();
                }
            }
            return inputAsInteger;
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

        // public static int ReadKey()
        // {
        //     while (true)
        //     {
        //         ConsoleKeyInfo choice = Console.ReadKey();
        //         char convertedChoice = choice.KeyChar;
        //         if (char.IsDigit(convertedChoice)) //choice.KeyChar))
        //         {
        //             int result = Convert.ToInt32(choice.KeyChar);
        //             return result;
        //         }
        //     }
        // }


    }
}