
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using IntroductionToBenchmarkDotNet.Models;

namespace IntroductionToBenchmarkDotNet.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.Net472)]
    public class GetByIdBenchmark
    {
        readonly List<Person> people = new();
        readonly int id = 1;

        [Params(10, 50, 100)]
        public int NumberOfIterations { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 1; i <= NumberOfIterations; i++)
            {
                var person = new Person { Id = i, Name = $"Name{i}" };
                people.Add(person);
            }
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
}