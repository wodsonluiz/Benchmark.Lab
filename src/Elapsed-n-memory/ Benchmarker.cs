using BenchmarkDotNet.Attributes;
using System.Linq;
using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Columns;

namespace Elapsed_n_memory;

[Config(typeof(Config))]
[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Arabic)]
public class  Benchmarker
{
    private static Random random = new Random();

    private int[] randomNumbers;

    //here we will parametrize each run of the benchmark, telling how many numbers array will contain
    [Params(100, 101)]
    public int N;

    //each run will have a common initilization
    [GlobalSetup]
    public void Setup()
    {
        randomNumbers = Enumerable.Range(0, N)
            .Select(_ => random.Next(1, N+1))
            .ToArray();   
    }

    //this is our AS-IS scenario, an implementation that we know it is being used production env
    [Benchmark(Baseline = true)]
    public int SumWithEnumerator() => SumCalculator.SumWithEnumerator(randomNumbers);

    // this is our proposed TO-BE scenario
    [Benchmark]
    public int SumWithFor() => SumCalculator.SumWithFor(randomNumbers);

    // this is another propesed TO-BE scenario
    [Benchmark]
    public int SumWithLinq() => SumCalculator.SumWithLinq(randomNumbers);

    private class Config: ManualConfig
    {
        public Config()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
        }
    }
}


