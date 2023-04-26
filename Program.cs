using System;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RecordLabelDatabaseContext();

            var bandCount = context.Bands.Count();
            Console.WriteLine($"There are {bandCount} bands!");
        }
    }
}