using System;
using System.Collections.Generic;

namespace ATMExercise.Models;

public partial class OperacionAdministrativa
{
    public int IdOperacionAdministrativa { get; set; }

    public int IdTarjeta { get; set; }

    public int IdTipoOperacion { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual Tarjetum IdTarjetaNavigation { get; set; } = null!;

    public virtual TipoOperacion IdTipoOperacionNavigation { get; set; } = null!;
}
