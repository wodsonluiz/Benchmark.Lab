namespace Benckmark.Console;

using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

public class Program
{
    static void Main(string[] args)
    {
        var config = new ManualConfig()
        .WithOptions(ConfigOptions.DisableOptimizationsValidator)
        .AddValidator(JitOptimizationsValidator.DontFailOnError)
        .AddLogger(ConsoleLogger.Default)
        .AddColumnProvider(DefaultColumnProviders.Instance);

        var summary = BenchmarkRunner.Run<FuncoesMatematicas>(config);
        Console.Read();
    }    
}

public class FuncoesMatematicas
{
    public double Number { get; set; } = 10;

    [Benchmark]
    public double NumeroAoQuadrado()
    {
        return Number * Number;
    }

    [Benchmark]
    public double NumeroAoQuadradoMathPow()
    {
        return Math.Pow(Number, 2);
    }
    
}
