namespace RhythmsGonnaGetYou
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public System.TimeSpan Duration { get; set; }
        public string d2 { get; set; }
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        // Add a song to an album
        public static void AddSong(RecordLabelDatabaseContext context)
        {
            // ####  ???
            // var songAlbum = RLDatabase.PromptForString("What album is this song on?");
            var songTitle = RLDatabase.PromptForString("What is the title of the song?");
            var songTrackNumber = RLDatabase.PromptForString("What is the track number?");
            var songDuration = RLDatabase.PromptForString("How long is the song? use 'm' for minutes and 's' for seconds");
        }

    }
}