using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly SamuraiContext Context = new SamuraiContext();
        
        static void Main(string[] args)
        {
            // GetSamurais("Before Add:");
            // AddSamurai();
            // InsertMultipleSamurais();
            // GetSamurais("After Add:");
            // Console.WriteLine("Press any key...");
            // QueryFilters();
            // Console.ReadKey();
            // RetrieveAndUpdateSamurai();
            RetrieveAndUpdateMultipleSamurais();
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = Context.Samurais.FirstOrDefault();
            if (samurai != null) samurai.Name += " Ling";
            Context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = Context.Samurais.Skip(1).Take(3).ToList();
            var battle = Context.Battles.AsNoTracking().FirstOrDefault();
            
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai {Name = "Julie"};
            Context.Samurais.Add(samurai);
            Context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = Context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void QueryFilters()
        {
            /*var name = "Bac";
            var samurais = Context.Samurais.Where(s => s.Name == name).ToList();*/
            var samurais = Context.Samurais.FirstOrDefault(s => EF.Functions.Like(s.Name, "J%"));
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai(){Name = "Bac"};
            var samurai1 = new Samurai(){Name = "Bac"};
            var samurai2 = new Samurai(){Name = "Bac"};
            Context.Samurais.AddRange(samurai, samurai1, samurai2);
            Context.SaveChanges();
        }
    }
}