
static void PrintList(List<string> MyList)
{
    foreach (string name in MyList)
    {
        Console.WriteLine(name);
    }
}
List<string> TestStringList = new List<string>() { "Harry", "Steve", "Carla", "Jeanne" };
PrintList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach (int number in IntList)
    {
        sum += number;
    }
    Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() { 2, 7, 12, 9, 3 };
SumOfNumbers(TestIntList);

static int FindMax(List<int> IntList)
{
    int highest = IntList[0];
    foreach (int number in IntList)
    {
        if (highest < number)
        {
            highest = number;
        }
    }
    Console.WriteLine(highest);
    return highest;
}
List<int> TestIntList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };
FindMax(TestIntList2);

static List<int> SquareValues(List<int> IntList)
{
    List<int> Squares = new List<int>();
    for (int i = 0; i < IntList.Count; i++)
    {
        Squares.Insert(i, IntList[i] * IntList[i]);
        Console.WriteLine(Squares[i]);
    }
    return Squares;
}
List<int> TestIntList3 = new List<int>() { 1, 2, 3, 4, 5 };
SquareValues(TestIntList3);

static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
        Console.WriteLine(IntArray[i]);
    }
    return IntArray;
}
int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
NonNegatives(TestIntArray);

static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach (KeyValuePair<string, string> pair in MyDictionary)
    {
        Console.WriteLine($"{pair.Key} - {pair.Value}");
    }
}
Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    if (MyDictionary.ContainsKey(SearchTerm))
    {
        return true;
    }
    else
    {
        return false;
    }
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> newDictionary = new Dictionary<string, int>();
    for (int i = 0; i < Names.Count; i++)
    {
        newDictionary.Add(Names[i], Numbers[i]);
    }
    Console.WriteLine(newDictionary);
    return newDictionary;
}
List<string> Names = new List<string>() { "Julie", "Harold", "James", "Monica" };
List<int> Numbers = new List<int>() { 6, 12, 7, 10 };
Console.WriteLine(string.Join(",", GenerateDictionary(Names, Numbers)));