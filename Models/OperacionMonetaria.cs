using System;
using System.Collections.Generic;

namespace ATMExercise.Models;

public partial class OperacionMonetaria
{
    public int IdOperacionMonetaria { get; set; }

    public int IdTarjeta { get; set; }

    public int IdTipoOperacion { get; set; }

    public DateTime FechaHora { get; set; }

    public double Monto { get; set; }

    public virtual Tarjeta IdTarjetaNavigation { get; set; } = null!;

    public virtual TipoOperacion IdTipoOperacionNavigation { get; set; } = null!;
}
