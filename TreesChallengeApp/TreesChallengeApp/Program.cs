﻿
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

tree.HightAdded += TreeHightAdded;

static void TreeHightAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano wysokość. Podaj kolejną wartość.");
}


Console.WriteLine(tree.Species);

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

var statistics = ((HightInFile)tree).GetStatistics();
{ 
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine(tree.Species);
    Console.WriteLine();
    Console.WriteLine("Statystyki:");
    Console.WriteLine($"Min: {statistics.Min}");
    Console.WriteLine($"Max: {statistics.Max}");
    Console.WriteLine($"Average: {statistics.Average:N2}");
    Console.WriteLine();
    Console.WriteLine($"Średni wiek drzew w drzewostanie:{statistics.AverageAge}");
}