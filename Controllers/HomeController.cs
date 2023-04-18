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
            var numeroTarjeta = tarjetaView.NumeroTarjeta;
            return View();
        }

        public IActionResult Operaciones(TarjetaViewModel tarjetaView)
        {
            var pinTarjeta = tarjetaView.PIN;
            return View();
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