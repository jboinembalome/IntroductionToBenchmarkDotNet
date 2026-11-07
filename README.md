# Introduction to BenchmarkDotNet

Source code used in the article [Introduction to BenchmarkDotNet](https://blouppy.com/blog/2022-10-22-introduction-to-benchmarkdotnet/) on the [Blouppy](https://blouppy.com) website.

It benchmarks three ways to find an element by its id in a `List<Person>` of 10, 50 and 100 items:
- a `foreach` loop,
- LINQ's `FirstOrDefault()`,
- LINQ's `SingleOrDefault()`,

with `[Params]`, `[GlobalSetup]`, `[GlobalCleanup]` and `[MemoryDiagnoser]` (allocations per operation).

## Project type
- Console application

## Project version
- .NET 10 (`net10.0`)

## NuGet Packages include
- **BenchmarkDotNet**: 0.15.8

## How to run it
You need the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

```powershell
dotnet run -c Release
```

Always run benchmarks in **Release**: BenchmarkDotNet refuses to give meaningful numbers for a Debug build.
The summary table is printed at the end and also written to `BenchmarkDotNet.Artifacts/results/`.

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!

## Support this project! :pray:
If you want to help me to maintain this project or add improvements, it would be a pleasure!
