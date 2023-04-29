// using System
using System;
using System.Collections.Generic;

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
        public static void ViewAllBands()
        {
            //possibly add IsBandSigned to this function
            var context = new RecordLabelDatabaseContext();
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
        public static void ViewSignedBands()
        {
            var context = new RecordLabelDatabaseContext();
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
        public static void ViewUnsignedBands()
        {
            var context = new RecordLabelDatabaseContext();
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
        public static void AddBand()
        {
            var context = new RecordLabelDatabaseContext();

            var bandName = RLDatabase.PromptForString("What is the name of the band?");
            var bandCountryOfOrigin = RLDatabase.PromptForString("What is the country of origin??");
            var bandNumberOfMembers = RLDatabase.PromptForInt("Number of members?");
            var bandWebsite = RLDatabase.PromptForString("What is the band website?");
            var bandStyle = RLDatabase.PromptForString("What is the genre or style of music?");
            var bandContactPerson = RLDatabase.PromptForString("Who is the contact person?");
            var bandContactPhoneNumber = RLDatabase.PromptForString("What is the contact phone number?");
            var bandIsSigned = RLDatabase.PromptForBool("Is the band signed? (Y)es or (n)o");

            var newBand = new Band
            {
                Name = bandName,
                CountryOfOrigin = bandCountryOfOrigin,
                NumberOfMembers = bandNumberOfMembers,
                Website = bandWebsite,
                Style = bandStyle,
                IsSigned = bandIsSigned,
                ContactName = bandContactPerson,
                ContactPhoneNumber = bandContactPhoneNumber
            };

            context.Bands.Add(newBand);
            context.SaveChanges();
        }

        // Resign a band (update isSigned to true)
        public static void ReSignBand()
        {
            var bandName = RLDatabase.PromptForString("What band would you like to re-sign?");
            //set isSigned TRUE
        }

        // Let a band go (update isSigned to false)
        public static void DropBand()
        {
            var bandName = RLDatabase.PromptForString("What band would you like to drop?");
            //set isSigned FALSE
        }

    }
}