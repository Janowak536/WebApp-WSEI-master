using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Models;

namespace WebApplication1.DAL.Contexts
{
    public class DziekanatDatabaseInitializer
    {
        public static void Initialize(DziekanatContext context)
        {
            context.Database.EnsureCreated();
            if (context.Zajecia.Any())
            {
                return;
            }
            else
            {
                var zajecia = new Zajecia[]
                {
                new Zajecia("Programowanie .NET",DateTime.Now.AddDays(2)),
                new Zajecia("Programowanie C#",DateTime.Now.AddDays(2).AddHours(4)),
                new Zajecia("Programowanie Java",DateTime.Now.AddDays(1).AddHours(2)),
                new Zajecia("Bazy danych",DateTime.Now.AddDays(3).AddHours(1)),
                new Zajecia("Wzorce projektowe",DateTime.Now.AddDays(5).AddHours(6)),
                new Zajecia("Zarządzanie projektem",DateTime.Now.AddDays(7).AddHours(3)),
                new Zajecia("UX",DateTime.Now.AddDays(4).AddHours(3)),
                new Zajecia("Microsoft",DateTime.Now.AddDays(1).AddHours(2))
                };
                foreach (Zajecia zajecia1 in zajecia)
                {
                    context.Zajecia.Add(zajecia1);
                }
            }
            if (context.Student.Any())
            {
                return;
            }
            else {
                var studenci = new Student[]
                {
                new Student ("111","Adam","Nowak" ),
                new Student ("222","Andrzej",  "Duda" ),
                new Student ("333","Anna","Rożek" ),
                new Student ("444","Justyna","Dzik" ),
                new Student ("555","Michał","Lis" ),
                new Student ("666","Daria","Nowak" ),
                new Student ("777","Mateusz","Mostowiak" )
                };
                foreach (Student student in studenci)
                {
                    context.Student.Add(student);
                }
            }
            context.SaveChanges();
        }
    }
}
