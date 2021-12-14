using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Models;
using WebApplication1.DAL.Contexts;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly DziekanatContext bazaDanychDziekanatu;

        public HomeController( DziekanatContext bazaDanychDziekanatu)
        {
            this.bazaDanychDziekanatu = bazaDanychDziekanatu;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     

        [HttpGet]
        public IActionResult PlanZajec()
        {
            //List<Zajecia> planZajec = bazaDanychDziekanatu.Zajecia.ToList();
            List<Zajecia> planZajec = bazaDanychDziekanatu.Zajecia.ToList();
            //List<Zajecia> planZajec2 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where word.NazwaZajec.StartsWith("Prog") select word).ToList();
            //List<Zajecia> planZajec3 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where word.NazwaZajec.Contains("J") select word).ToList();
            //List<Zajecia> planZajec4 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where !word.NazwaZajec.Contains(" ") select word).ToList();
            //List<Zajecia> planZajec5 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia select new Zajecia() {Id = word.Id, NazwaZajec = word.NazwaZajec.Substring(0, 3), TerminZajec= word.TerminZajec}).ToList();

            return View(planZajec);
        }


        [HttpGet]
        public IActionResult Student()
        {
            List<Student> students = bazaDanychDziekanatu.Student.ToList();
            return View(students);
        }
        [HttpPost]
        [Route("DodajStudenta/{numerIndeksu}/{imie}/{nazwisko}")]
        public IActionResult DodajStudenta(string numerIndeksu, string imie,string nazwisko)
        {
            try
            {
                Student student = new Student(numerIndeksu, imie, nazwisko);
                bazaDanychDziekanatu.Student.Add(student);
                bazaDanychDziekanatu.SaveChanges();
                return Ok(new { komunikat = $"Dodano studenta {imie} {nazwisko} o numerze indueksu: {numerIndeksu}" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { komunikat = $"Nie udało się dodać studenta {imie} do bazy: {ex.Message}" });
            }
        }
        [HttpPost]
        [Route("UsunStudenta/{numerIndeksu}")]
        public IActionResult UsunStudenta(string numerIndeksu)
        {
            try
            {
                Student student = bazaDanychDziekanatu.Student.Where(x=>x.NumerIndeksu==numerIndeksu).FirstOrDefault();
                bazaDanychDziekanatu.Student.Remove(student);
                bazaDanychDziekanatu.SaveChanges();
                return Ok(new { komunikat = $"Usunięto Studenta {student.Imie} o numerze indeksu {student.NumerIndeksu} z bazy." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { komunikat = $"Nie udało się usunąć studenta {numerIndeksu} z bazy: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("DodajZajeciaDoBazy/{podanaNazwa}/{podanyTermin}")]
        public IActionResult DodajDoPlanu(string podanaNazwa, string podanyTermin)
        {
            try
            {
                DateTime data = Convert.ToDateTime(podanyTermin);
                if (data.Date <= DateTime.Now.Date)
                    return BadRequest(new { komunikat = $"Nie można dodać zajęć dla minionej daty" });
                Zajecia zajecia = new Zajecia(podanaNazwa, data);
                bazaDanychDziekanatu.Zajecia.Add(zajecia);
                bazaDanychDziekanatu.SaveChanges();
                return Ok(new { komunikat = $"Dodano zajęcia {podanaNazwa}, w terminie {data}, do bazy." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { komunikat = $"Nie udało się dodać zajęć {podanaNazwa} do bazy: {ex.Message}" });
            }
        }
        [HttpPost]
        [Route("UsunZajeciaZBazy/{idZajec}")]
        public IActionResult UsunZPlanu(int idZajec)
        {
            try
            {
                Zajecia zajecia = bazaDanychDziekanatu.Zajecia.Where(x => x.Id == idZajec).FirstOrDefault();
                bazaDanychDziekanatu.Zajecia.Remove(zajecia);
                bazaDanychDziekanatu.SaveChanges();
                return Ok(new { komunikat = $"Usunięto zajęcia {zajecia.NazwaZajec} o Id {zajecia.Id} z bazy." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { komunikat = $"Brak zajęć dla id {idZajec}: {ex.Message}" });
            }
        }
    }
}
