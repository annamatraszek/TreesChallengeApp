
using TreesChallengeApp;

Console.WriteLine("================================================================================");
//Console.WriteLine(" ");
Console.WriteLine("Witamy w progranie do szacowania wieku drzewostanu na postawie wysokości drzew");
Console.WriteLine("oraz obliczania parametrów drzewa !");
//Console.WriteLine(" ");
Console.WriteLine("================================================================================");
Console.WriteLine();
Console.WriteLine("Gatunek drzewa:");

var input1 = Console.ReadLine();
var tree = new HightInFile(input1);

//var tree = new HightInFile("sosna zwyczajna");

tree.HightAdded += TreeHightAdded;

static void TreeHightAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano wysokość.");
    Console.WriteLine("Podaj kolejną wartość lub wpisz 'q', aby zakończyć.");
}

Console.WriteLine("Podaj wysokość drzewa: ");

while (true)
{
    //Console.WriteLine("Podaj wysokość drzewa: ");
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }

    try
    {
        tree.AddHight(input);
    }
    catch (Exception e)
    {
        Console.WriteLine($"exception catched: {e.Message}");
    }
}

var statistics = tree.GetStatistics();
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine();
    // Console.WriteLine(tree.Species);
    Console.WriteLine(input1);
    Console.WriteLine();
    Console.WriteLine("Statystyki:");
    Console.WriteLine($"Count: {statistics.Count}");
    Console.WriteLine($"Min: {statistics.Min}");
    Console.WriteLine($"Max: {statistics.Max}");
    Console.WriteLine($"Average: {statistics.Average}");
    Console.WriteLine();
    Console.WriteLine($"Średnia wysokość drzew: " + ($"{statistics.Average:N0} ") + "m");
    Console.WriteLine();
    Console.WriteLine($"Średni wiek drzew w drzewostanie: " + ($"{statistics.AverageAge} "));
}


