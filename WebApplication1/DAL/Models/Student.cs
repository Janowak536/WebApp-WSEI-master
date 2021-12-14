using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DAL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string NumerIndeksu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Student(string numerIndeksu,string imie,string nazwisko)
        {
            NumerIndeksu = numerIndeksu;
            Imie = imie;
            Nazwisko = nazwisko;
        }
        
    }
}
