# Benchmark.Lab

### Output

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
Intel Core i7-10610U CPU 1.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  Job-FHBDKH : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2

IterationCount=1  WarmupCount=2  

```
|            Method |   N |      Mean | Error |         Ratio | RatioSD | Rank |   Gen0 | Allocated | Alloc Ratio |
|------------------ |---- |----------:|------:|--------------:|--------:|-----:|-------:|----------:|------------:|
|        SumWithFor | 100 |  34.01 ns |    NA | 13.13x faster |   0.00x |    1 |      - |         - |          NA |
|       SumWithLinq | 100 |  43.52 ns |    NA | 10.26x faster |   0.00x |    2 |      - |         - |          NA |
| SumWithEnumerator | 100 | 446.70 ns |    NA |      baseline |         |    3 | 0.0076 |      32 B |             |
|                   |     |           |       |               |         |      |        |           |             |
|        SumWithFor | 101 |  35.53 ns |    NA | 12.46x faster |   0.00x |    1 |      - |         - |          NA |
|       SumWithLinq | 101 |  43.91 ns |    NA | 10.08x faster |   0.00x |    2 |      - |         - |          NA |
| SumWithEnumerator | 101 | 442.53 ns |    NA |      baseline |         |    3 | 0.0076 |      32 B |             |

