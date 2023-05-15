using System;
using BenchmarkDotNet.Running;

namespace Elapsed_n_memory;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Microbenchmark elapsed time and memory allocation with BenchmarkDotNet!");

        var sumary = BenchmarkRunner.Run<Benchmarker>(null, args);
    }
}
