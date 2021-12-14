using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Contexts;
using WebApplication1.DAL.Models;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class ObslugaBazyDanych : IObslugaBazyDanych
    {
        private readonly DziekanatContext bazaDanychDziekanatu;

        public ObslugaBazyDanych(DziekanatContext bazaDanychDziekanatu)
        {
            this.bazaDanychDziekanatu = bazaDanychDziekanatu;
        }


        public Zajecia DodajZajeciaDoPlanu(string podanaNazwa, string podanyTermin)
        {
            using var transaction = bazaDanychDziekanatu.Database.BeginTransaction();

            try
            {
                Zajecia zajecia = new Zajecia(podanaNazwa, DateTime.Now);
                Debug.WriteLine($"Id: {zajecia.Id}");

                bazaDanychDziekanatu.Zajecia.Add(zajecia);
                bazaDanychDziekanatu.SaveChanges();
                Debug.WriteLine($"Id: {zajecia.Id}");

                DateTime data = Convert.ToDateTime(podanyTermin);
                if (data.Date <= DateTime.Now.Date)
                {
                    throw new Exception("Data nie może być wcześniejsza niż dzisiaj");
                }
                Debug.WriteLine($"TerminZajec: {zajecia.TerminZajec}");
                bazaDanychDziekanatu.Zajecia.Where(x => x.Id == zajecia.Id).First().TerminZajec = data;
                bazaDanychDziekanatu.SaveChanges();
                Debug.WriteLine($"TerminZajec: {zajecia.TerminZajec}");
   
                transaction.Commit();
                return zajecia;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                transaction.Rollback();
                return null;
            }
        }
        public Zajecia UsunZajeciaZPlanu(int idZajec)
        {
            try
            {
                Zajecia zajecia = bazaDanychDziekanatu.Zajecia.Where(x => x.Id == idZajec).FirstOrDefault();
                bazaDanychDziekanatu.Zajecia.Remove(zajecia);
                bazaDanychDziekanatu.SaveChanges();
                return zajecia;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public List<Zajecia> PobierzPlanZajec()
        {
            #region
            //List<Zajecia> planZajec = bazaDanychDziekanatu.Zajecia.ToList();
            //List<Zajecia> planZajec2 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where word.NazwaZajec.StartsWith("Prog") select word).ToList();
            //List<Zajecia> planZajec3 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where word.NazwaZajec.Contains("J") select word).ToList();
            //List<Zajecia> planZajec4 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where !word.NazwaZajec.Contains(" ") select word).ToList();
            //List<Zajecia> planZajec5 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia select new Zajecia() {Id = word.Id, NazwaZajec = word.NazwaZajec.Substring(0, 3), TerminZajec= word.TerminZajec}).ToList();
            #endregion
            return bazaDanychDziekanatu.Zajecia.ToList();
        }
        public List<Student> PobierzListeStudentów()
        {
            return bazaDanychDziekanatu.Student.ToList();
        }

        public Student DodajStudentaDoListy(string numerIndeksu, string imie, string nazwisko)
        {
            using var transaction = bazaDanychDziekanatu.Database.BeginTransaction();
            try
            {
                Student student = new Student(numerIndeksu, imie,nazwisko);
                Debug.WriteLine($"Numer indeksu: {student.NumerIndeksu}");

                bazaDanychDziekanatu.Student.Add(student);
                bazaDanychDziekanatu.SaveChanges();
                Debug.WriteLine($"Numer indeksu: {student.NumerIndeksu}");

                Debug.WriteLine($"Imie: {student.Imie}");
                
                bazaDanychDziekanatu.SaveChanges();
                Debug.WriteLine($"Nazwisko: {student.Nazwisko}");

                transaction.Commit();
                return student;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                transaction.Rollback();
                return null;
            }
        }
        public Student UsunStudentaZPlanu(string numerIndeksu)
        {
            try
            {
                Student student = bazaDanychDziekanatu.Student.Where(x => x.NumerIndeksu == numerIndeksu).FirstOrDefault();
                bazaDanychDziekanatu.Student.Remove(student);
                bazaDanychDziekanatu.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
    }
}
