using SharpCompress.Writers;
using System;
using System.Diagnostics;

namespace EscapeFromTheWoods
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
    
            string mongoConnectionString = "mongodb://localhost:27017"; 
            string databaseName = "EscapeFromTheWoodsDatabase"; 

            DBwriter db = new DBwriter(mongoConnectionString, databaseName);

            string path = @"C:\Users\32495\Desktop\Bitmap";
            Map m1 = new Map(0, 2000, 0, 2000);
            m1.Grid.CreateGrid(10000); // Grid voor m1 initialiseren met gridSize 10
            Wood w1 = WoodBuilder.GetWood(100000, m1, path, db);
            w1.PlaceMonkey("Alice", IDgenerator.GetMonkeyID());
            w1.PlaceMonkey("Janice", IDgenerator.GetMonkeyID());
            w1.PlaceMonkey("Toby", IDgenerator.GetMonkeyID());
            w1.PlaceMonkey("Mindy", IDgenerator.GetMonkeyID());
            w1.PlaceMonkey("Jos", IDgenerator.GetMonkeyID());

            Map m2 = new Map(0, 200, 0, 200);
            m2.Grid.CreateGrid(10000); // Grid voor m2 initialiseren met gridSize 10
            Wood w2 = WoodBuilder.GetWood(10000, m2, path, db);
            w2.PlaceMonkey("Tom", IDgenerator.GetMonkeyID());
            w2.PlaceMonkey("Jerry", IDgenerator.GetMonkeyID());
            w2.PlaceMonkey("Tiffany", IDgenerator.GetMonkeyID());
            w2.PlaceMonkey("Mozes", IDgenerator.GetMonkeyID());
            w2.PlaceMonkey("Jebus", IDgenerator.GetMonkeyID());

            Map m3 = new Map(0, 200, 0, 200);
            m3.Grid.CreateGrid(10000); // Grid voor m3 initialiseren met gridSize 10
            Wood w3 = WoodBuilder.GetWood(25000, m3, path, db);
            w3.PlaceMonkey("Kelly", IDgenerator.GetMonkeyID());
            w3.PlaceMonkey("Kenji", IDgenerator.GetMonkeyID());
            w3.PlaceMonkey("Kobe", IDgenerator.GetMonkeyID());
            w3.PlaceMonkey("Kendra", IDgenerator.GetMonkeyID());

            WoodBuilder.AssignTreesToGrid(w1, m1.Grid);
            WoodBuilder.AssignTreesToGrid(w2, m2.Grid);
            WoodBuilder.AssignTreesToGrid(w3, m3.Grid);

            //w1.writeRouteToDB(;
            //w2.writeRouteToDB();
            //w3.writeRouteToDB();
            w1.Escape(m1.Grid, 10); // Voorbeeld van straal (radius) = 10
            w2.Escape(m2.Grid, 15); // Voorbeeld van straal (radius) = 15
            w3.Escape(m3.Grid, 12); // Voorbeeld van straal (radius) = 12

            stopwatch.Stop();
            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("end");
        }
    }
}
