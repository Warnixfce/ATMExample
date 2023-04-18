using System;
using System.Collections.Generic;

namespace ATMExercise.Models;

public partial class EstadoTarjetum
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Tarjetum> Tarjeta { get; set; } = new List<Tarjetum>();
}
