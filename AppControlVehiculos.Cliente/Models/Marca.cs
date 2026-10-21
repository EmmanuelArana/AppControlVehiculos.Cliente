using System;
using System.Collections.Generic;

namespace AppControlVehiculos.Cliente.Models;

public partial class Marca
{
    public int MarcaId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
