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
using WebApplication1.Services;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IObslugaBazyDanych obslugaBazyDanych;

        public HomeController(IObslugaBazyDanych obslugaBazyDanych)
        {
            this.obslugaBazyDanych = obslugaBazyDanych;
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
        [Route("PlanZajec")]
        public IActionResult PlanZajec()
        {
            return Ok(obslugaBazyDanych.PobierzPlanZajec());
        }

        [HttpGet]
        [Route("Student")]
        public IActionResult Student()
        {
            return Ok(obslugaBazyDanych.PobierzListeStudentów());
        }

        [HttpPost]
        [Route("DodajStudenta/{numerIndeksu}/{imie}/{nazwisko}")]
        public IActionResult DodajStudenta(string numerIndeksu, string imie, string nazwisko)
        {
            Student student = obslugaBazyDanych.DodajStudentaDoListy(numerIndeksu,imie,nazwisko);

            if (numerIndeksu == null)
                return BadRequest(new { komunikat = $"Nie udało się dodać studenta {numerIndeksu}" });

            return Ok(new { komunikat = $"Dodano studenta {student.Imie} do bazy." });
        }

        [HttpPost]
        [Route("UsunStudenta/{numerIndeksu}")]
        public IActionResult UsunStudenta(string numerIndeksu)
        {
            Student student = obslugaBazyDanych.UsunStudentaZPlanu(numerIndeksu);

            if (student.NumerIndeksu != null)
            {
                return Ok(new { komunikat = $"Usunięto studenta {student.Imie} {student.Nazwisko} z bazy." });
            }
            return BadRequest(new { komunikat = $"Brak studenta dla id {numerIndeksu}" });
        }

        [HttpPost]
        [Route("DodajZajeciaDoBazy/{podanaNazwa}/{podanyTermin}")]
        public IActionResult DodajDoPlanu(string podanaNazwa, string podanyTermin)
        {

            Zajecia zajecia = obslugaBazyDanych.DodajZajeciaDoPlanu(podanaNazwa, podanyTermin);

            if (zajecia == null)
                return BadRequest(new { komunikat = $"Nie udało się dodać zajęć {podanaNazwa}" });

            return Ok(new { komunikat = $"Dodano zajęcia {zajecia.NazwaZajec} do bazy." });



        }

        [HttpPost]
        [Route("UsunZajeciaZBazy/{idZajec}")]
        public IActionResult UsunZPlanu(int idZajec)
        {
            Zajecia zajecia = obslugaBazyDanych.UsunZajeciaZPlanu(idZajec);

            if (zajecia.NazwaZajec != null)
            {
                return Ok(new { komunikat = $"Usunięto zajęcia {zajecia.NazwaZajec} o Id {zajecia.Id} z bazy." });
            }
            return BadRequest(new { komunikat = $"Brak zajęć dla id {idZajec}" });

        }
    }
}
