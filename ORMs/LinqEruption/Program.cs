List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");

// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
Eruption firstEruptionChile = eruptions
    .Where(c => c.Location == "Chile")
    .OrderBy(y => y.Year)
    .First();
Console.WriteLine("First Eruption in Chile");
Console.WriteLine(firstEruptionChile);

Eruption firstEruptionHawaii = eruptions
    .Where(c => c.Location == "Hawaiian Is")
    .OrderBy(y => y.Year)
    .First();
if (firstEruptionHawaii != null)
{
    Console.WriteLine("First Eruption in Hawaii");
    Console.WriteLine(firstEruptionHawaii);
}
else
{
    Console.WriteLine("No Hawaiian Eruption Found");
}

IEnumerable<Eruption> newZealand = eruptions.Where(l => l.Location == "New Zealand").Where(y => y.Year > 1900);
PrintEach(newZealand, "New Zealand > 1900");

IEnumerable<Eruption> elevation = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(elevation, "Elevations above 2000");

IEnumerable<Eruption> lName = eruptions.Where(n => n.Volcano.StartsWith("L"));
PrintEach(lName, "Volcanoes beginning with L");
Console.WriteLine(lName.Count());

int maxElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine("Highest Elevation");
Console.WriteLine(maxElevation);

Eruption nameElevation = eruptions.First(e => e.ElevationInMeters == maxElevation);
Console.WriteLine(nameElevation.Volcano);

IEnumerable<Eruption> orderedAlphabet = eruptions.OrderBy(a => a.Volcano);
PrintEach(orderedAlphabet, "Alphabetical by name");

int elevationSum = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine(elevationSum);

Boolean year2000 = eruptions.Any(y => y.Year == 2000);
Console.WriteLine(year2000);

IEnumerable<Eruption> firstThree = eruptions.Where(v => v.Type == "Stratovolcano").Take(3);
PrintEach(firstThree, "First Three Stratos");

IEnumerable<Eruption> lastOne = eruptions.Where(v => v.Year < 1000).OrderBy(v => v.Volcano);
PrintEach(lastOne, "All eruptions before 1000");

IEnumerable<string> lastOneName = eruptions.Where(v => v.Year < 1000).OrderBy(v => v.Volcano).Select(v => v.Volcano);
Console.WriteLine("All eruptions before 1000 redux");
foreach (string name in lastOneName)
{
Console.WriteLine(name);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
