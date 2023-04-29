using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RecordLabelDatabaseContext();
            var songsWithAlbums = context.Songs.Include(song => song.Album);

            RLDatabase.Menu();
        }
    }
}