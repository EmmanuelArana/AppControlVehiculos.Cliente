using AppControlVehiculos.DTO.Response.Modelo;
using AppControlVehiculos.Negocio.Interfaces;
using AppControlVehiculos.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Negocio.Implementaciones
{
    public class ModeloNegocio : IModeloNegocio
    {
        private readonly IModeloRepositorio _repositorio;

        public ModeloNegocio(IModeloRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<ModeloResponse>> Listar()
        {
            var lista = await _repositorio.Listar();

            return lista.Select(m => new ModeloResponse
            {
                ModeloId = m.ModeloId,
                Nombre = m.Nombre
            }).ToList();
        }
    }

}
