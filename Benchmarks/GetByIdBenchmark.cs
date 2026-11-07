using BenchmarkDotNet.Attributes;
using IntroductionToBenchmarkDotNet.Models;

namespace IntroductionToBenchmarkDotNet.Benchmarks;

// Adds the Allocated column (bytes allocated per operation).
[MemoryDiagnoser]
public class GetByIdBenchmark
{
    readonly List<Person> people = [];
    readonly int id = 1;

    // Set of values.
    // Runs a benchmark for each
    // combination of parametric values.
    [Params(10, 50, 100)]
    public int Iterations { get; set; }

    // Executed once per benchmark case (method + parameter value),
    // before its iterations start, not before every invocation.
    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 1; i <= Iterations; i++)
        {
            var person = new Person { Id = i, Name = $"Name{i}" };
            people.Add(person);
        }
    }

    // Executed once per benchmark case, after its iterations.
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        // E.g: Dispose
    }

    // Target the method that will be executed as a benchmark.
    [Benchmark]
    public Person? Foreach()
    {
        foreach (var person in people)
        {
            if (person.Id == id)
                return person;
        }

        return null;
    }

    // Target the method that will be executed as a benchmark.
    [Benchmark]
    public Person? FirstOrDefault()
        => people.FirstOrDefault(x => x.Id == id);

    // Target the method that will be executed as a benchmark.
    [Benchmark]
    public Person? SingleOrDefault()
        => people.SingleOrDefault(x => x.Id == id);
}
