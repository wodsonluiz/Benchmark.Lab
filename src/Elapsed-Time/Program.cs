using System.Diagnostics;

namespace Elapsed_Time;
class Program
{
    private static List<string> cities = new List<string>{
        "São Paulo",
        "Rio de Janeiro",
        "Salvador",
        "Brasília",
        "Fortaleza",
        "Belo Horizonte",
        "Manaus",
        "Curitiba",
        "Recife",
        "Porto Alegre",
        "Belém",
        "Goiânia",
        "Guarulhos",
        "Campinas",
        "São Luís",
        "São Gonçalo",
        "Maceió",
        "Duque de Caxias",
        "Natal",
        "Teresina"
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Microbenchmark with elapsed time");
        const int N = 20;
        Random rand = new Random();

        for (int iter = 0; iter < 5; iter++)
        {
            var measurements = GetMeasurements();

            for (int i = 0; i < N; i++)
            {
                
            }

            var sw = new Stopwatch();
            sw.Start();
            FindWithLinq("Teresina");
            sw.Stop();
            measurements["linq"].Add(sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            FindWithForench("Teresina");
            sw.Stop();
            measurements["forench"].Add(sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            FindWithFor("Teresina");
            sw.Stop();
            measurements["for"].Add(sw.Elapsed.TotalMilliseconds);
            

            System.Console.WriteLine($"Iteration {iter + 1}");
            DisplayStatics(measurements);
        }
    }

    static Dictionary<string, List<double>> GetMeasurements()
    {
        return new Dictionary<string, List<double>>
        {
            ["linq"] = new List<double>(),
            ["forench"] = new List<double>(),
            ["for"] = new List<double>()
        };
    }

    static void DisplayStatics(Dictionary<string, List<double>> measurements)
    {
        System.Console.WriteLine(new string('-', 57));
        System.Console.WriteLine("Approach| Minimum\t| Maximum\t| Average\t");
        System.Console.WriteLine(new string('-', 57));

        foreach (var item in measurements)
        {
            System.Console.Write(item.Key);
            System.Console.Write($"\t| {measurements[item.Key].Min():N5} ms\t");
            System.Console.Write($"\t| {measurements[item.Key].Max():N5} ms\t");
            System.Console.WriteLine($"\t| {measurements[item.Key].Average():N5} ms\t");
        }
        System.Console.WriteLine();
    }

    static bool FindWithLinq(string city)
    {
        return cities.Any(currentCity => currentCity == city); 
    }

    static bool FindWithForench(string city)
    {
        foreach (var currentCity in cities)
        {
            if(currentCity == city)
                break;
        }

        return true;
    }

    static bool FindWithFor(string city)
    {
        for (int i = 0; i < cities.Count; i++)
        {
            string? currentCity = cities[i];
            if (currentCity == city)
                break;
        }

        return true;
    }
}
