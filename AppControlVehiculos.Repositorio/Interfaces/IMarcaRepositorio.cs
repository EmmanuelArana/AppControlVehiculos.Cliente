using AppControlVehiculos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Repositorio.Interfaces
{
    public interface IMarcaRepositorio
    {
        Task<List<Marca>> Listar();
    }
}
