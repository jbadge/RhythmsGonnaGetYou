using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }

        public Band Band { get; set; }
        public List<Song> Songs { get; set; }

        // View all albums of band, using prompt
        public static void ViewAllAlbumsByBand(RecordLabelDatabaseContext context)
        {
            var band = RLDatabase.PromptForString("What band do you want to see albums for?").ToLower();
            var albumsWithBands = context.Albums.Include(album => album.Band);

            // Album search resulting in album title and band name
            foreach (var album in albumsWithBands)
            {
                if (album.Band.Name.ToLower() == band || album.Band.Name.ToLower() == "the " + band)
                {
                    Console.WriteLine($"{album.Title}.");
                }
            }
        }

        // View all albums by...(currently only) release date
        public static void ViewAlbumsBy(RecordLabelDatabaseContext context)
        {
            // give ability to order by ______, not just release date
            // var sortBy = RLDatabase.PromptForString("How would you like the albums sorted?").ToLower(); 

            // var albumsByReleaseDate = context.Albums.Where(album => album.Band != null).OrderBy(album => album.ReleaseDate).Include(album => album.Band);
            var albumsByReleaseDate = context.Albums.Include(album => album.Band).OrderBy(album => album.ReleaseDate);

            foreach (var album in albumsByReleaseDate)
            {
                Console.WriteLine($"{album.ReleaseDate.ToString("MM/dd/yyyy")} - {album.Title} by {album.Band.Name}");
            }
        }

        // Add an album for a band
        public static void AddAlbum(RecordLabelDatabaseContext context)
        {
            var bandName = RLDatabase.PromptForString("What is the name of the band?");
            var bandToAddAlbum = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == bandName.ToUpper());

            if (bandToAddAlbum != null)
            {
                var albumTitle = RLDatabase.PromptForString("What is the title of the album?");
                var albumTitleToAdd = context.Albums.FirstOrDefault(album => album.Title.ToUpper() == albumTitle.ToUpper());

                var isValidDate = false;
                if (albumTitleToAdd == null)
                {
                    while (!isValidDate)
                    {
                        DateTime albumReleaseDate;

                        if (DateTime.TryParse(RLDatabase.PromptForString("When was the album released? use mm/dd/yyyy"), out albumReleaseDate))
                        {
                            String.Format("MM/0:d/yyyy", albumReleaseDate);
                            isValidDate = true;

                            var newAlbum = new Album
                            {
                                Title = albumTitle,
                                IsExplicit = RLDatabase.PromptForBool("Is the album explicit? (Y)es or (n)o"),
                                ReleaseDate = albumReleaseDate,
                                BandId = bandToAddAlbum.Id
                            };

                            context.Albums.Add(newAlbum);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Invalid");
                            RLDatabase.DialogueRefresher();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Album is already in the database");
                    RLDatabase.DialogueRefresher();
                }
            }
            else
            {
                Console.WriteLine("Band does not exist in the database.");
                RLDatabase.DialogueRefresher();
            }
        }

    }
}