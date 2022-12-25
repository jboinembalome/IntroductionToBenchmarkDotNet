using BenchmarkDotNet.Running;
using IntroductionToBenchmarkDotNet.Benchmarks;

// Run all benchmarks in the GetByIdBenchmark class
var summary = BenchmarkRunner.Run<GetByIdBenchmark>();
