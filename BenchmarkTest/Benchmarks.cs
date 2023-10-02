using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
    public class Benchmarks
    {
        List<Slug> slugs;
        Random _rand = new Random();

        [GlobalSetup]
        public void Setup()
        {
            slugs = new List<Slug>();

            for (int i = 0; i < 1000; i++)
            {
                slugs.Add(new Slug
                {
                    Culture = "en-US",
                    Id = Guid.NewGuid(),
                    Value = i,
                    ResourceId = i.ToString(),
                    Version = 1
                });
            }
        }

        //[Benchmark]
        //public void For()
        //{
        //    for (int i = 0; i < slugs.Count; i++)
        //    {
        //        var slug = slugs[i];
        //    }
        //}

        //[Benchmark]
        //public void ForEach()
        //{
        //    foreach (var item in slugs)
        //    {
        //        var slug = item;
        //    }
        //}

        //[Benchmark]
        //public void ShuffleList()
        //{
        //    for(int i=slugs.Count-1; i>0; i--)
        //    {
        //        var k = _rand.Next(i + 1);
        //        var val = slugs[k];
        //        slugs[k] = slugs[i];
        //        slugs[i] = val;
        //    }
        //}

        [Benchmark]
        public void SortListAsscending()
        {
            var list = slugs.OrderBy(x => x.Id).ToList();
        }

        [Benchmark]
        public void SortListDescending()
        {
            var list = slugs.OrderByDescending(x => x.Id).ToList();
        }

        public List<Slug> MergeSort(List<Slug> unsortedList)
        {
            if(unsortedList.Count <= 1)
                return unsortedList;

            List<Slug> left = new List<Slug>();
            List<Slug> right = new List<Slug>();

            var middle = unsortedList.Count / 2;

            for(int i = 0; )
        }
    }
}
