using ATMExercise.Models.ViewModels;
using ATMExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult AddNumberT(string num, string tar = "")
        {
            var tarjetaNum = new TarjetaViewModel();
            tarjetaNum.NumeroTarjeta = tar;

            if (tar.Length <= 18)
            {
                if ((tar.Length + 1) % 5 == 0)
                {
                    tarjetaNum.NumeroTarjeta += "-";
                }
                tarjetaNum.NumeroTarjeta += num;
                return View("Index", tarjetaNum);
            }
            else
            {
                return View("Index", tarjetaNum);
            }
        }

        public IActionResult PIN(TarjetaViewModel tarjetaView)
        {
            if(tarjetaView.NumeroTarjeta.Contains("-"))
            {
                tarjetaView.NumeroTarjeta = tarjetaView.NumeroTarjeta.Replace("-", "");
            }
            //Validar numero tarjeta
            if (_context.Tarjeta.Any(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta))
            {
                Tarjeta tarjetaMatch = _context.Tarjeta.FirstOrDefault(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta);
                if (tarjetaMatch.IdEstado == 1)
                {
                    if (tarjetaMatch.Intentos > 0)
                    {
                        ViewBag.Mensaje = "Recuerde que ya tiene intentos incorrectos";
                        tarjetaView.Intentos = tarjetaMatch.Intentos.ToString();
                    }
                    if(tarjetaMatch.Intentos == 0)
                    {
                        tarjetaView.Intentos = tarjetaMatch.Intentos.ToString();
                    }
                    return View(tarjetaView);
                }
                else
                {
                    //TODO sacar esto
                    //tarjetaMatch.Intentos = 0;
                    //tarjetaMatch.IdEstado = 1;
                    //_context.SaveChanges();
                    EstadoTarjeta estadoTarjeta = _context.EstadoTarjeta.FirstOrDefault(m => m.IdEstado == tarjetaMatch.IdEstado);
                    return View("Errores", new ErrorViewModel { RequestId = $"La tarjeta se encuentra {estadoTarjeta.Nombre}. Por favor solicite asistencia de un representante del banco." });
                }
            }
            else
            {
                return View("Errores", new ErrorViewModel { RequestId = "La tarjeta no existe. Por favor solicite asistencia de un representante del banco." });
            }
        }

        public IActionResult AddPinT(string num, string pin = "", string numeroTarj = "", string intentos = "")
        {
            var tarjetaPin = new TarjetaViewModel();
            tarjetaPin.PIN = pin;
            tarjetaPin.NumeroTarjeta= numeroTarj;
            tarjetaPin.Intentos = intentos;

            if (pin.Length < 4) //1289
            {
                tarjetaPin.PIN += num;
                ModelState.Clear();
                return View("PIN", tarjetaPin);
            }
            else
            {
                return View("PIN", tarjetaPin);
            }
        }

        public IActionResult Operaciones(TarjetaViewModel tarjetaView)
        {
            if (_context.Tarjeta.Any(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta && m.Pin.ToString() == tarjetaView.PIN))
            {
                Tarjeta tarjetaMatch = _context.Tarjeta.FirstOrDefault(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta && m.Pin.ToString() == tarjetaView.PIN);
                tarjetaView.Id_Tarjeta = tarjetaMatch.IdTarjeta.ToString();
                tarjetaView.FechaVencimiento = tarjetaMatch.FechaVencimiento.ToString();
                tarjetaView.Balance = tarjetaMatch.Balance.ToString();
                tarjetaView.Id_Estado = tarjetaMatch.IdEstado.ToString();
                return View(tarjetaView);
            }
            else if (tarjetaView.NumeroTarjeta == null)
            {
                return View();
            }
            else
            {
                Tarjeta tarjetaMatch = _context.Tarjeta.FirstOrDefault(m => m.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta);
                tarjetaMatch.Intentos++;
                _context.SaveChanges();
                tarjetaView.Intentos = tarjetaMatch.Intentos.ToString();
                if (tarjetaMatch.Intentos >= 4)
                {
                    if(tarjetaMatch.IdEstado != 2)
                    {
                        tarjetaMatch.IdEstado = 2;
                    }
                    _context.SaveChanges();
                    return View("Errores", new ErrorViewModel { RequestId = "Ha llegado al límite de intentos máximos de ingreso de PIN. La tarjeta se ha bloqueado. Por favor solicite asistencia de un representante del banco."});
                }
                else
                {
                    ViewBag.Mensaje = "Dato erróneo. Ingrese el PIN nuevamente.";
                    return View("PIN", tarjetaView);
                }
            }
        }

        public IActionResult Errores(TarjetaViewModel tarjetaView)
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