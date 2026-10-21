using System;
using System.Collections.Generic;

namespace AppControlVehiculos.Cliente.Models;

public partial class TipoMantenimiento
{
    public int TipoMantenimientoId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
}
