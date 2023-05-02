// using System
using System;
using System.Collections.Generic;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }

        public List<Album> Albums { get; set; }

        // View all the bands
        public static void ViewAllBands(RecordLabelDatabaseContext context)
        {
            var bands = context.Bands;

            foreach (var band in bands)
            {
                if (band.Name == null)
                {
                    Console.WriteLine($"There are no bands in the database.");
                }
                else
                {
                    Console.WriteLine($"{band.Name}");
                }
            }
        }

        // View all bands that are signed
        public static void ViewSignedBands(RecordLabelDatabaseContext context)
        {
            var bands = context.Bands;

            foreach (var band in bands)
            {
                if (band.Name == null)
                {
                    Console.WriteLine($"There are no bands in the database.");
                }
                else if (band.IsSigned == true)
                {
                    Console.WriteLine($"{band.Name}");
                }
            }
        }

        // View all bands that are not signed
        public static void ViewUnsignedBands(RecordLabelDatabaseContext context)
        {
            var bands = context.Bands;

            foreach (var band in bands)
            {
                if (band.Name == null)
                {
                    Console.WriteLine($"There are no bands in the database.");
                }
                else if (band.IsSigned == false)
                {
                    Console.WriteLine($"{band.Name}");
                }
            }
        }

        // Add a band to the database
        public static void AddBand(RecordLabelDatabaseContext context)
        {
            var bandName = RLDatabase.PromptForString("What is the name of the band?");
            var bandToCheck = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == bandName.ToUpper());

            if (bandToCheck != null)
            {
                Console.WriteLine($"{bandToCheck.Name} already exists in the database.");
                RLDatabase.DialogueRefresher();
            }
            else
            {
                var newBand = new Band
                {
                    Name = bandName,
                    CountryOfOrigin = RLDatabase.PromptForString("What is the country of origin?"),
                    NumberOfMembers = RLDatabase.PromptForInt("Number of members?"),
                    Website = RLDatabase.PromptForString("What is the band website?"),
                    Style = RLDatabase.PromptForString("What is the genre or style of music?"),
                    IsSigned = RLDatabase.PromptForBool("Is the band signed? (Y)es or (n)o"),
                    ContactName = RLDatabase.PromptForString("Who is the contact person?"),
                    ContactPhoneNumber = RLDatabase.PromptForString("What is the contact phone number?")
                };

                context.Bands.Add(newBand);
                context.SaveChanges();
            }
        }

        // Resign a band (update isSigned to true)
        public static void ReSignBand(RecordLabelDatabaseContext context)
        {
            var bandName = RLDatabase.PromptForString("What band would you like to re-sign?");
            var bandToReSign = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == bandName.ToUpper());

            if (bandToReSign != null)
            {
                if (bandToReSign.IsSigned == false)
                {
                    bandToReSign.IsSigned = true;
                    context.SaveChanges();
                    Console.WriteLine($"You successfully re-signed {bandToReSign.Name}.");
                }
                else
                {
                    Console.WriteLine($"{bandToReSign.Name} is already signed!");
                }
            }
            else
            {
                Console.WriteLine("Band does not exist in the database.");
            }
            RLDatabase.DialogueRefresher();
        }

        // Let a band go (update isSigned to false)
        public static void DropBand(RecordLabelDatabaseContext context)
        {
            var bandName = RLDatabase.PromptForString("What band would you like to drop?");
            var bandToDrop = context.Bands.FirstOrDefault(band => band.Name.ToUpper() == bandName.ToUpper());

            if (bandToDrop != null)
            {
                if (bandToDrop.IsSigned == true)
                {
                    bandToDrop.IsSigned = false;
                    context.SaveChanges();
                    Console.WriteLine($"You successfully dropped {bandToDrop.Name}.");
                }
                else
                {
                    Console.WriteLine($"{bandToDrop.Name} is not signed!");
                }
            }
            else
            {
                Console.WriteLine("Band does not exist in the database.");
            }
            RLDatabase.DialogueRefresher();
        }

    }
}
