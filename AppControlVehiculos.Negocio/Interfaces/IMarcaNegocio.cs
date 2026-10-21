using AppControlVehiculos.DTO.Response.Marca;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Negocio.Interfaces
{
    public interface IMarcaNegocio
    {
        Task<List<MarcaResponse>> Listar();
    }
}
