using AppControlVehiculos.AccesoDatos;
using AppControlVehiculos.Entities;
using AppControlVehiculos.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Repositorio.Implementacion
{
    public class ModeloRepositorio : IModeloRepositorio
    {
        private readonly DbAbb191BdvehiculosContext _bd;
        public ModeloRepositorio(DbAbb191BdvehiculosContext bd)
        {
            _bd = bd;
        }

        // async permite usar await dentro del metodo, await permite espera a que se complete un tarea asincrona
        public async Task<List<Modelo>> Listar() // Task indica que el metodo devolvera una lista de forma asincronica
        {
            return await _bd.Modelos.Where(p => p.Activo == true).ToListAsync();
        }
    }
}
