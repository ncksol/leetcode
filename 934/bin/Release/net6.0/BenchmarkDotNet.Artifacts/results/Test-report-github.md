``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-10600KF CPU 4.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|       Method |       Mean |    Error |   StdDev |
|------------- |-----------:|---------:|---------:|
| BenchmarkOne |   245.4 μs |  4.80 μs |  7.04 μs |
| BenchmarkTwo | 1,751.9 μs | 22.71 μs | 21.24 μs |
