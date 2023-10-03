
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Sebastian";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzień Dobry" : "Dobry WIeczór";
            return View();

            Dane[] osoby =
            {
                new Dane {Name = "Sebastian", Surname="Trybulec"},
                new Dane {Name = "Jan" , Surname="Kowalski"},
                new Dane {Name = "Anna", Surname="Trybulec"},
            };
            return View(osoby);
        }
        public IActionResult Urodziny(Urodziny urodziny) 
        {
                ViewBag.powiatnie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok}";
            return View(urodziny);
        }
  
       
        public IActionResult Calculator(Calculatorr calc)
        {
            {
                ViewBag.wynik = "Wpisz dane";
                
                switch (calc.znak)
                {
                    case "+":
                        ViewBag.wynik = $"Wynik to: {calc.num1 + calc.num2}";
                        break;
                    case "-":
                        ViewBag.wynik = $"Wynik to: {calc.num1 - calc.num2}";
                        break;
                    case "*":
                        ViewBag.wynik = $"Wynik to: {calc.num1 * calc.num2}";
                        break;
                    case "/":
                        if (calc.num2 != 0)
                        {
                            ViewBag.wynik = $"Wynik to: {calc.num1 / calc.num2}";
                        }
                        else
                        {
                            ViewBag.wynik = "Błąd: nie można dzielić przez zero";
                        }
                        break;
                    default:
                        ViewBag.wynik = "Nieprawidłowy znak";
                        break;
                }

                return View();
            }

        }
    }
}