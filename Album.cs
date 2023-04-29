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
        public static void ViewAllAlbumsByBand()
        {
            var context = new RecordLabelDatabaseContext();
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
        public static void ViewAlbumsBy()
        {
            // give ability to order by ______, not just release date
            // var sortBy = RLDatabase.PromptForString("How would you like the albums sorted?").ToLower(); 
            var context = new RecordLabelDatabaseContext();

            // var albumsByReleaseDate = context.Albums.Where(album => album.Band != null).OrderBy(album => album.ReleaseDate).Include(album => album.Band);
            var albumsByReleaseDate = context.Albums.Include(album => album.Band).OrderBy(album => album.ReleaseDate);

            foreach (var album in albumsByReleaseDate)
            {
                Console.WriteLine($"{album.ReleaseDate.ToString("MM/dd/yyyy")} - {album.Title} by {album.Band.Name}");
            }
        }

        // Add an album for a band
        public static void AddAlbum()
        {
            var albumTitle = RLDatabase.PromptForString("What is the title of the album?");
            var albumIsExplicit = RLDatabase.PromptForString("Is the album explicit?");
            var albumReleaseDate = RLDatabase.PromptForString("When was the album released? use mm/dd/yyyy");
        }

    }
}