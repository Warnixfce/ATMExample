using System;
using System.Collections.Generic;

namespace ATMExercise.Models;

public partial class EstadoTarjeta
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Tarjeta> Tarjeta { get; set; } = new List<Tarjeta>();
}
