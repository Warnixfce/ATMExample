using ATMExercise.Models.ViewModels;
using ATMExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ATMExercise.Controllers
{
    public class OpDisponiblesController : Controller
    {
        private readonly ILogger<OpDisponiblesController> _logger;
        private AtmContext _context;

        public OpDisponiblesController(ILogger<OpDisponiblesController> logger, AtmContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Balance(TarjetaViewModel tarjetaView)
        {            
            var tarjetas = _context.Tarjeta.ToList();
            var tarjetaMatcheada = new TarjetaViewModel();
            
            foreach (var item in tarjetas)
            {
                if(item.Pin.ToString() == tarjetaView.PIN)
                {
                    tarjetaMatcheada.Id_Tarjeta = item.IdTarjeta.ToString();
                    tarjetaMatcheada.NumeroTarjeta = item.NumeroTarjeta.ToString();
                    tarjetaMatcheada.PIN = item.Pin.ToString();
                    tarjetaMatcheada.FechaVencimiento = item.FechaVencimiento.ToString();
                    tarjetaMatcheada.Balance = item.Balance.ToString();
                    tarjetaMatcheada.Id_Estado = item.IdEstado.ToString();
                }                
            }

            return View(tarjetaMatcheada);
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
