using ATMExercise.Models.ViewModels;
using ATMExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.NetworkInformation;

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
            //var tarjetas = _context.Tarjeta.ToList();
            //var tarjetaMatch = new TarjetaViewModel();
            
            if (_context.Tarjeta.Any(m => m.IdTarjeta.ToString() == tarjetaView.Id_Tarjeta))
            {
                Tarjeta tarjetaMatch = _context.Tarjeta.FirstOrDefault(m => m.IdTarjeta.ToString() == tarjetaView.Id_Tarjeta);

                #region ActualizacionDB
                OperacionAdministrativa opAdmin = new OperacionAdministrativa();
                opAdmin.IdTarjeta = tarjetaMatch.IdTarjeta;                
                var tipoOp = _context.TipoOperacion.FirstOrDefault(x=>x.Nombre == "Consulta");
                opAdmin.IdTipoOperacion = tipoOp.IdTipoOperacion;
                opAdmin.FechaHora = DateTime.Now;                               
                _context.Add(opAdmin);
                _context.SaveChanges();
                #endregion

                #region DatosTajetaMostrados
                tarjetaView.Id_Tarjeta = tarjetaMatch.IdTarjeta.ToString();
                tarjetaView.FechaHoraRegistro = opAdmin.FechaHora.ToString();
                tarjetaView.Balance = tarjetaMatch.Balance.ToString();
                tarjetaView.Id_Estado = tarjetaMatch.IdEstado.ToString();
                #endregion

            }

            return View(tarjetaView);

            //foreach (var item in tarjetas)
            //{
            //    if (item.NumeroTarjeta.ToString() == tarjetaView.NumeroTarjeta && item.Pin.ToString() == tarjetaView.PIN)
            //    {
            //        tarjetaMatch.Id_Tarjeta = item.IdTarjeta.ToString();
            //        tarjetaMatch.NumeroTarjeta = item.NumeroTarjeta.ToString();
            //        tarjetaMatch.PIN = item.Pin.ToString();
            //        tarjetaMatch.FechaVencimiento = item.FechaVencimiento.ToString();
            //        tarjetaMatch.Balance = item.Balance.ToString();
            //        tarjetaMatch.Id_Estado = item.IdEstado.ToString();
            //    }
            //}

            //return View(tarjetaMatch);
        }

        public IActionResult Retiro(TarjetaViewModel tarjetaView)
        {
            Tarjeta tarjetaMatch = _context.Tarjeta.FirstOrDefault(m => m.IdTarjeta.ToString() == tarjetaView.Id_Tarjeta);

            if(tarjetaMatch == null)
            {
                return View("Errores", new ErrorViewModel { RequestId = "Tarjeta inexistente. Por favor solicite asistencia de un representante del banco." });
            }
            else
            {
                if (tarjetaMatch.Balance < decimal.Parse(tarjetaView.MontoRetiro))
                {
                    return View("Errores", new ErrorViewModel { RequestId = "Fondos insuficientes. Ingrese un monto a retirar menor al disponible." });
                }
                else
                {
                    tarjetaMatch.Balance -= decimal.Parse(tarjetaView.MontoRetiro);
                    _context.SaveChanges();

                    #region ActualizacionDB
                    OperacionMonetaria opMon = new OperacionMonetaria();
                    opMon.IdTarjeta = tarjetaMatch.IdTarjeta;
                    var tipoOp = _context.TipoOperacion.FirstOrDefault(x => x.Nombre == "Retiro");
                    opMon.IdTipoOperacion = tipoOp.IdTipoOperacion;
                    opMon.FechaHora = DateTime.Now;
                    opMon.Monto = Convert.ToDecimal(tarjetaView.MontoRetiro);
                    _context.Add(opMon);
                    _context.SaveChanges();
                    #endregion


                    #region DatosRetiroMostrados
                    OperacionViewModel opRetiro = new OperacionViewModel();
                    opRetiro.IdTarjeta = tarjetaMatch.IdTarjeta.ToString();
                    opRetiro.NumeroTarjeta = tarjetaMatch.NumeroTarjeta.ToString();
                    opRetiro.Pin = tarjetaMatch.Pin.ToString();
                    opRetiro.TipoOperacion = tipoOp.Nombre;
                    opRetiro.FechaHora = opMon.FechaHora.ToString();
                    opRetiro.Monto = tarjetaView.MontoRetiro;
                    opRetiro.Balance = tarjetaMatch.Balance.ToString();
                    #endregion

                    return View("Reporte", opRetiro);
                }
            }            
        }

        public IActionResult AddMontoT(string num, string idTar, string monto = "")
        {
            var tarjetaExtrac = new TarjetaViewModel();
            tarjetaExtrac.Id_Tarjeta = idTar;
            tarjetaExtrac.MontoRetiro = monto;

            tarjetaExtrac.MontoRetiro += num;
            //ModelState.Clear();

            return View("Retiro", tarjetaExtrac);

        }


        public IActionResult Reporte(TarjetaViewModel tarjetaView, OperacionViewModel operacionView)
        {
            return View();
        }
    }
}
