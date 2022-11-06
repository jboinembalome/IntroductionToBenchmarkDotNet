using BenchmarkDotNet.Running;
using IntroductionToBenchmarkDotNet.Benchmarks;

var summary = BenchmarkRunner.Run<GetByIdBenchmark>();
