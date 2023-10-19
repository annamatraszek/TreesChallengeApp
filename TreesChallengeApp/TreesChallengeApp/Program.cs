
using TreesChallengeApp;

Console.WriteLine("================================================================================");
//Console.WriteLine(" ");
Console.WriteLine("Witamy w progranie do szacowania wieku drzewostanu na postawie wysokości drzew");
Console.WriteLine("oraz obliczania parametrów drzewa !");
//Console.WriteLine(" ");
Console.WriteLine("================================================================================");
Console.WriteLine();
Console.WriteLine("Gatunek drzewa:");

var tree = new HightInFile("dąb");

//species.HightAdded += SpeciesHightAdded;

Console.WriteLine(tree.Species);

//var tree = new HightInFile();

//var input = Console.ReadLine();
//if (input == "sosna"|| input =="dąb"|| input == "brzoza")
//{
//    Console.WriteLine(input);
//}

//try
//{
//    species.AddSpecies(input);
//}
//catch (Exception e)
//{
//    Console.WriteLine($"exception catched: {e.Message}");
//}


while (true)
{
    Console.WriteLine("Podaj wysokość drzewa: ");
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

//Console.WriteLine(species);