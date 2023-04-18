using System;
using System.Collections.Generic;

namespace ATMExercise.Models;

public partial class Tarjetum
{
    public int IdTarjeta { get; set; }

    public long NumeroTarjeta { get; set; }

    public int Pin { get; set; }

    public string FechaVencimiento { get; set; } = null!;

    public double Balance { get; set; }

    public int IdEstado { get; set; }

    public virtual EstadoTarjetum IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<OperacionAdministrativa> OperacionAdministrativas { get; set; } = new List<OperacionAdministrativa>();

    public virtual ICollection<OperacionMonetarium> OperacionMonetaria { get; set; } = new List<OperacionMonetarium>();
}
