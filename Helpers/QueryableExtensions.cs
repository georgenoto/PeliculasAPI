using PeliculasAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO) {
            return queryable.Skip((paginacionDTO.pagina - 1) * paginacionDTO.CantidadRegistrosPorPagina)
                   .Take(paginacionDTO.CantidadRegistrosPorPagina);                
        }
    }
}
