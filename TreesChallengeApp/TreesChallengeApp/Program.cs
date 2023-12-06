﻿
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TreesChallengeApp;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("================================================================================");
//Console.WriteLine();
WriteLine(ConsoleColor.DarkCyan, "Witamy w programie do szacowania wieku drzewostanu.");

void WriteLine(ConsoleColor color, string v)
{
    Console.ForegroundColor = color;
    Console.WriteLine(v);
    Console.ResetColor();
}

Console.WriteLine("Program szacuje średni wiek drzewostanu w obrębie działki na podstawie wysokości drzew");
//Console.WriteLine(" ");

Console.WriteLine("================================================================================");
//Console.WriteLine();
bool CloseApp = false;

while (!CloseApp)
{
    //Console.WriteLine("Program szacuje średni wiek drzewostanu w obrebie działki na podstawie wysokości drzew. ");
    Console.WriteLine("\n" +
        "Wciśnij '1' jeżeli chcesz obliczyć średni wiek dla poszczególnych gatunków drzew \n" +
        "Wcisnij '2' jeżeli chcesz obliczyć średni wiek wszystkich drzew na działce\n" +
        "Wcisnij 'x' jeżeli chcesz zakończyc program\n");

    Console.WriteLine("Press key 1, 2 or x: ");
    var userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            SpeciesAgeOnParcel();
            break;

        case "2":
            TreesAgeOnParcel();
            break;

        case "x":
            CloseApp = true;
            break;

        default:
            Console.WriteLine("Invalid operation.\n");
            continue;
    }
}

static void SpeciesAgeOnParcel()
{
    Console.WriteLine("Podaj numer działki:");

    string parcelNumber = Console.ReadLine();

    Console.WriteLine("Gatunek drzewa:");

    string species = Console.ReadLine();

    var tree = new HightInFile(parcelNumber, species);

    tree.HightAdded += TreeHightAdded;

    //Console.WriteLine("Podaj wysokość drzewa: ");

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
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }

    var statistics = tree.GetStatistics();
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine(tree.Species);
        //Console.WriteLine(species);
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
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
    }
}

static void TreesAgeOnParcel()
{
    Console.WriteLine("Podaj numer działki:");
    string parcelNumber = Console.ReadLine();

    var parc = new HightInParcel(parcelNumber);

    while (true)
    {
        Console.WriteLine("Gatunek drzewa:");
        string species = Console.ReadLine();

        List<string> speciesNames = new List<string>();

        //public void AddToListSpeciesName();
        {
            //string species = speciesN;
            speciesNames.Add(species);
        }

        var tree = new HightInParcel(parcelNumber, species);

        tree.HightAdded += TreeHightAdded;

        if (species == "q")
        {
            break;
        }

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
                Console.WriteLine($"Exception catched: {e.Message}");
            }
        }

    }

    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine($"Na działce nr {parcelNumber} wystepują gatunki:  ");



    //var speciesNamesT = new List<string> ShowListSpeciesTree();

    //var speciesNamesT = parc.ShowListSpeciesTree();
    //{
    //    var speciesNames = new List<string>(speciesNamesT);

    //    foreach (var specName in speciesNames)
    //    {
    //        Console.WriteLine($"{specName}");
    //    }

    //}

    // var speciesNamesT = new List<string>(HightInParcel.speciesNames);   

    //List<string> speciesNamesT = new List<string> ();


    List<string> ShowListSpeciesTree(List<string> speciesNames)
    {
        var spec = new List<string>(speciesNames);

        string result = null;
        foreach (var s in spec)
        {
            result += s;
            string t = result;
        }
        return spec;

        Console.WriteLine($"{spec}");
    }

    var statistics = parc.GetStatistics();
    {
        Console.WriteLine();
        Console.WriteLine("Statystyki:");
        Console.WriteLine($"Liczba zmierzonych drzew: {statistics.Count}");
        Console.WriteLine($"Hight Min: {statistics.Min}");
        Console.WriteLine($"Hight Max: {statistics.Max}");
        Console.WriteLine($"Average: {statistics.Average}");
        Console.WriteLine();
        Console.WriteLine($"Średnia wysokość drzew: " + ($"{statistics.Average:N0} ") + "m");
        Console.WriteLine();
        Console.WriteLine($"Średni wiek drzew w drzewostanie: " + ($"{statistics.AverageAge} "));
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();
    }
}

static void TreeHightAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano wysokość.");
    Console.WriteLine("Podaj kolejną wartość lub wpisz 'q', aby zakończyć.");
}