namespace ATMExercise.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public int Attempts { get; set; }

        public string Id_Tarjeta { get; set; }

        public string NumeroTarjeta { get; set; }

        public string PIN { get; set; }

    }
}