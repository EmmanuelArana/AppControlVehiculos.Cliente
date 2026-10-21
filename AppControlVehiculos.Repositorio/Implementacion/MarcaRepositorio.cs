using AppControlVehiculos.AccesoDatos;
using AppControlVehiculos.Entities;
using AppControlVehiculos.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppControlVehiculos.Repositorio.Implementacion
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly DbAbb191BdvehiculosContext _bd;
        public MarcaRepositorio(DbAbb191BdvehiculosContext bd) 
        { 
            _bd = bd;
        }

        // async permite usar await dentro del metodo, await permite espera a que se complete un tarea asincrona
        public async Task<List<Marca>> Listar() // Task indica que el metodo devolvera una lista de forma asincronica
        {
            return await _bd.Marcas.Where(p=>p.Activo==true).ToListAsync();
        }
    }
}
