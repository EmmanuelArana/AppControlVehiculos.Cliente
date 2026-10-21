using AppControlVehiculos.DTO.Response.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Negocio.Interfaces
{
    public interface IModeloNegocio
    {
        Task<List<ModeloResponse>> Listar();
    }
}
