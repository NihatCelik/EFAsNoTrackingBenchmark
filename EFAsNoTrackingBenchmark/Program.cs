using BenchmarkDotNet.Running;
using Bogus;
using EFAsNoTrackingBenchmark.Contexts;
using EFAsNoTrackingBenchmark.Entities;
using System;

namespace EFAsNoTrackingBenchmark
{
    class Program
    {
        static UserDbContext userDbContext = new UserDbContext();
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<TrackingVsAsNoTracking>();
            //GenerateData(); 50 bin kayıt oluşturmak için Bogus kullandım. 
            Console.ReadLine();
        }

        static void GenerateData()
        {
            var userFaker = new Faker<User>()
              .RuleFor(u => u.Name, u => u.Person.FirstName)
              .RuleFor(u => u.Surname, u => u.Person.LastName)
              .RuleFor(u => u.UserName, (u, x) => u.Internet.UserName(x.Name, x.Surname))
              .RuleFor(u => u.Password, u => u.Internet.Password());

            var generatedUser = userFaker.Generate(50000);
            userDbContext.AddRange(generatedUser);
            userDbContext.SaveChanges();
        }
    }
}
