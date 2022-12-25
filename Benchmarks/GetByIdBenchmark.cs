
using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Jobs;
using IntroductionToBenchmarkDotNet.Models;

namespace IntroductionToBenchmarkDotNet.Benchmarks
{
    // Run all benchmarks for each frameworks.
    // (P.S: You need to update the .csproj to target several frameworks and disable "ImplicitUsings" and "Nullable")
    //[SimpleJob(RuntimeMoniker.Net60)]
    //[SimpleJob(RuntimeMoniker.Net48)]
    //[SimpleJob(RuntimeMoniker.Net472)]
    public class GetByIdBenchmark
    {
        readonly List<Person> people = new();
        readonly int id = 1;

        // Set of values.
        // Runs a benchmark for each 
        // combination of parametric values.
        [Params(10, 50, 100)]
        public int NumberOfIterations { get; set; }

        // Executed before all benchmark iterations. 
        // It will be executed only once.
        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 1; i <= NumberOfIterations; i++)
            {
                var person = new Person { Id = i, Name = $"Name{i}" };
                people.Add(person);
            }
        }

        // Executed after all benchmark iterations. 
        // It will be executed only once.
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
}