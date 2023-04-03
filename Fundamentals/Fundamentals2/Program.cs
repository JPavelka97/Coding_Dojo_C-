// See https://aka.ms/new-console-template for more information
int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

string[] names = { "Tim", "Martin", "Nikki", "Sara" };

Boolean[] booleans = new Boolean[10];
for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0)
    {
        booleans[i] = true;
    }
    else
    {
        booleans[i] = false;
    }
}

List<string> IceCream = new List<string>();
IceCream.Add("Vanilla");
IceCream.Add("Chocolate");
IceCream.Add("Strawberry");
IceCream.Add("Cookies and Cream");
IceCream.Add("Rocky Road");

Console.WriteLine(IceCream.Count());
Console.WriteLine(IceCream[2]);

IceCream.RemoveAt(2);

Console.WriteLine(IceCream.Count());
Console.WriteLine(IceCream[2]);

Dictionary<string,string> PeopleFlavors = new Dictionary<string,string>();

Random rand = new Random();

for (int i = 0; i<4; i++){
    PeopleFlavors.Add(names[i],IceCream[rand.Next(0,4)]);
}

foreach(KeyValuePair<string,string> name in PeopleFlavors){
    Console.WriteLine($"{name.Key} - {name.Value}");
}