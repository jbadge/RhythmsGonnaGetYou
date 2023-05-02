using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string d2 { get; set; }
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        // Add a song to an album
        public static void AddSong(RecordLabelDatabaseContext context)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                var songAlbum = RLDatabase.PromptForString("What album is this song on?");
                var albumToAddSong = context.Albums.Include(album => album.Songs).FirstOrDefault(album => album.Title.ToUpper() == songAlbum.ToUpper());

                // If album is not in database
                if (albumToAddSong == null)
                {
                    bool usingMenu2 = true;

                    Console.WriteLine("Cannot add songs until album is added to the database.");
                    Console.WriteLine();

                    while (usingMenu2)
                    {
                        var menuInput = RLDatabase.PromptForChar("Would you like to add an album? [Y/n]").ToUpper();

                        switch (menuInput)
                        {
                            case "Y":
                                Album.AddAlbum(context);
                                break;
                            case "N":
                                menuInput = RLDatabase.PromptForChar("Would you like to add another song to the database? [Y/n]");

                                switch (menuInput)
                                {
                                    case "Y":
                                        usingMenu2 = false;
                                        break;
                                    case "N":
                                        usingMenu = false;
                                        usingMenu2 = false;
                                        break;
                                    default:
                                        Console.WriteLine("Please pick a valid option.");
                                        RLDatabase.DialogueRefresher();
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Please pick a valid option.");
                                RLDatabase.DialogueRefresher();
                                break;
                        }
                    }
                }

                // If album is in database
                else
                {
                    var songTitle = RLDatabase.PromptForString("What is the title of the song?");
                    var songTitleToAdd = context.Songs.FirstOrDefault(song => song.Title.ToUpper() == songTitle.ToUpper());

                    var userTrackNumber = RLDatabase.PromptForInt("What is the track number?");
                    var isUsedTrackNumber = albumToAddSong.Songs.Any(song => song.TrackNumber == userTrackNumber);

                    // If track number is used and song title exists
                    if (isUsedTrackNumber != false && songTitleToAdd != null)
                    {
                        Console.WriteLine("Song is already in the database.");
                        RLDatabase.DialogueRefresher();
                    }
                    // If track number is used
                    else if (isUsedTrackNumber != false && songTitleToAdd == null)
                    {
                        Console.WriteLine("Track number is already in use.");
                        RLDatabase.DialogueRefresher();
                    }
                    // If track number is unused in current album
                    else
                    {
                        var newSong = new Song
                        {
                            Title = songTitle,
                            TrackNumber = userTrackNumber,
                            Duration = TimeSpan.Parse(RLDatabase.PromptForString("What is the duration of the song? [hh:mm:ss] ")),
                            AlbumId = albumToAddSong.Id
                        };
                        context.Songs.Add(newSong);
                        context.SaveChanges();
                    }
                    usingMenu = false;
                }
            }
        }
    }
}