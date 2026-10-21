using AppControlVehiculos.DTO.Response.Marca;
using AppControlVehiculos.Negocio.Interfaces;
using AppControlVehiculos.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Negocio.Implementaciones
{
    public class MarcaNegocio : IMarcaNegocio
    {
        private readonly IMarcaRepositorio _repositorio;

        public MarcaNegocio(IMarcaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<MarcaResponse>> Listar()
        {
            var lista = await _repositorio.Listar();

            return lista.Select(p => new MarcaResponse
            {
                Nombre = p.Nombre,
                MarcaId = p.MarcaId
                
            }).ToList();

        }
    }   
}
