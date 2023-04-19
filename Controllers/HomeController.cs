using ATMExercise.Models.ViewModels;
using ATMExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ATMExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AtmContext _context;

        public HomeController(ILogger<HomeController> logger, AtmContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var opeMoney = _context.OperacionMonetaria.ToList();
            //var opeAdmin = _context.OperacionAdministrativas.ToList();
            //var tarjetas = _context.Tarjeta.ToList();
            //var tipoOp = _context.TipoOperacions.ToList();


            //List<OperacionViewModel> lista = new List<OperacionViewModel>();

            //foreach (var item in opeMoney)
            //{
            //    OperacionViewModel operacion = new OperacionViewModel();
            //    operacion.NumeroTarjeta = tarjetas.FirstOrDefault(x => x.IdTarjeta == item.IdTarjeta).NumeroTarjeta.ToString();
            //    operacion.TipoOperacion = tipoOp.FirstOrDefault(y => y.IdTipoOperacion == item.IdTipoOperacion).Nombre;
            //    operacion.FechaHora = item.FechaHora.ToString();
            //    operacion.Monto = item.Monto.ToString();                
            //    lista.Add(operacion);
            //}

            //foreach (var item in opeAdmin)
            //{
            //    OperacionViewModel operacion = new OperacionViewModel();
            //    operacion.NumeroTarjeta = tarjetas.FirstOrDefault(x => x.IdTarjeta == item.IdTarjeta).NumeroTarjeta.ToString();
            //    operacion.TipoOperacion = tipoOp.FirstOrDefault(y => y.IdTipoOperacion == item.IdTipoOperacion).Nombre;
            //    operacion.FechaHora = item.FechaHora.ToString();
            //    operacion.Monto = "-";
            //    lista.Add(operacion);
            //}

            return View(new TarjetaViewModel());
        }

        public IActionResult PIN(TarjetaViewModel tarjetaView)
        {
            //Validar numero tarjeta
            if (_context.Tarjeta.Any(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta))
            {
                Tarjeta tarjetaMatch = _context.Tarjeta.FirstOrDefault(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta);
                if (tarjetaMatch.IdEstado == 1)
                {
                    return View(tarjetaView);
                }
                else
                {
                    EstadoTarjeta estadoTarjeta = _context.EstadoTarjeta.FirstOrDefault(m=>m.IdEstado == tarjetaMatch.IdEstado);
                    return View("Errores", new ErrorViewModel { RequestId = $"Error - La tarjeta se encuentra {estadoTarjeta.Nombre}. Por favor solicite asistencia de un representante del banco."});
                }               
            }
            else
            {
                return View("Errores",new ErrorViewModel { RequestId= "Error - La tarjeta no existe. Por favor solicite asistencia de un representante del banco." });
            }
        }

        public IActionResult Operaciones(TarjetaViewModel tarjetaView)
        {
            if (_context.Tarjeta.Any(m => m.Pin.ToString() == tarjetaView.PIN))
            {
                Tarjeta tarjetaMatch = _context.Tarjeta.FirstOrDefault(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta && m.Pin.ToString() == tarjetaView.PIN);
                tarjetaView.Id_Tarjeta = tarjetaMatch.IdTarjeta.ToString();
                tarjetaView.FechaVencimiento = tarjetaMatch.FechaVencimiento.ToString();
                tarjetaView.Balance = tarjetaMatch.Balance.ToString();
                tarjetaView.Id_Estado = tarjetaMatch.IdEstado.ToString();
                return View(tarjetaView);
            }
            else if(tarjetaView.NumeroTarjeta == null)
            {
                return View();
            }
            else
            {
                return View("Errores", new ErrorViewModel { RequestId = "anda paya bobo" });
            }
        }

        public IActionResult Errores()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}