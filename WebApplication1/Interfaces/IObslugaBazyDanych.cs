using System.Collections.Generic;
using WebApplication1.DAL.Models;

namespace WebApplication1.Interfaces
{
    public interface IObslugaBazyDanych
    {
        Zajecia DodajZajeciaDoPlanu(string podanaNazwa, string podanyTermin);
        List<Zajecia> PobierzPlanZajec();
        Zajecia UsunZajeciaZPlanu(int idZajec);

        List<Student> PobierzListeStudentów();
        Student DodajStudentaDoListy(string numerIndeksu, string imie, string nazwisko);
        Student UsunStudentaZPlanu(string numerIndeksu);
    }
}