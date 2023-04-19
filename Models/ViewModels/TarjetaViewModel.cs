using System.ComponentModel.DataAnnotations;

namespace ATMExercise.Models.ViewModels
{
    public class TarjetaViewModel
    {
        public string Id_Tarjeta { get; set; }

        public string NumeroTarjeta { get; set; }

        public string PIN { get; set; }

        public string FechaVencimiento { get; set; }
        
        public string Balance { get; set; }

        public string Id_Estado { get; set; }
    }
}
