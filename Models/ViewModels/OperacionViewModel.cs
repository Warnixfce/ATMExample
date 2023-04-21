namespace ATMExercise.Models.ViewModels
{
    public class OperacionViewModel
    {
        public string IdTarjeta { get; set; }

        public string NumeroTarjeta { get; set; }

        public string Pin { get; set; }

        public string TipoOperacion { get; set; }

        public string FechaHora { get; set; }

        public string Monto { get; set; }

        public string Balance { get; set; }

        public enum OperacionRealiz
        {
            Consulta = 0,
            Retiro = 1,
            Ingreso = 2
        }

    }
}
