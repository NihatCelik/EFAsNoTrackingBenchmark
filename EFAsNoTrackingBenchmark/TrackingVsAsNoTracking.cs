using BenchmarkDotNet.Attributes;
using EFAsNoTrackingBenchmark.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFAsNoTrackingBenchmark
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net50, launchCount: 3, warmupCount: 5, targetCount: 3)]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, launchCount: 3, warmupCount: 5, targetCount: 3)]
    [MeanColumn, MedianColumn]
    [MemoryDiagnoser]
    public class TrackingVsAsNoTracking
    {
        [Benchmark]
        public void Tracking_OneRow()
        {
            using var db = new UserDbContext();
            db.Users.Take(1).ToList();
        }

        [Benchmark]
        public void NoTracking_OneRow()
        {
            using var db = new UserDbContext();
            db.Users.Take(1).AsNoTracking().ToList();
        }

        [Benchmark]
        public void Tracking_AllRows()
        {
            using var db = new UserDbContext();
            db.Users.ToList();
        }

        [Benchmark]
        public void NoTracking_AllRows()
        {
            using var db = new UserDbContext();
            db.Users.AsNoTracking().ToList();
        }

    }
}
