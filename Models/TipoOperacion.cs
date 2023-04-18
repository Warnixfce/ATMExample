using System;
using System.Collections.Generic;

namespace ATMExercise.Models;

public partial class TipoOperacion
{
    public int IdTipoOperacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<OperacionAdministrativa> OperacionAdministrativas { get; set; } = new List<OperacionAdministrativa>();

    public virtual ICollection<OperacionMonetarium> OperacionMonetaria { get; set; } = new List<OperacionMonetarium>();
}
