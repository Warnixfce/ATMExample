using ATMExercise.Models.ViewModels;
using ATMExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ATMExercise.Controllers
{
    public class OpDisponiblesController : Controller
    {
        public IActionResult Balance()
        {
            return View();
        }
        public IActionResult Retiro()
        {
            return View();
        }
        public IActionResult Reporte()
        {
            return View();
        }
    }
}
