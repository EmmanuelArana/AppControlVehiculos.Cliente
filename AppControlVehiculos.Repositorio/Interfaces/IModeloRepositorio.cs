using AppControlVehiculos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Repositorio.Interfaces
{
    public interface IModeloRepositorio
    {
        Task<List<Modelo>> Listar();
    }
}
