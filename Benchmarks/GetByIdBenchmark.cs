using BenchmarkDotNet.Attributes;
using IntroductionToBenchmarkDotNet.Models;

namespace IntroductionToBenchmarkDotNet.Benchmarks;

[MemoryDiagnoser]
public class GetByIdBenchmark
{
    readonly List<Person> people = [];
    readonly int id = 1;

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

    [Benchmark]
    public Person? FirstOrDefault()
        => people.FirstOrDefault(x => x.Id == id);

    [Benchmark]
    public Person? SingleOrDefault()
        => people.SingleOrDefault(x => x.Id == id);
}
