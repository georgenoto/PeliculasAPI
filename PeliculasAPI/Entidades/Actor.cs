using Microsoft.AspNetCore.Http;
using PeliculasAPI.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        [Required] 
        [StringLength(120)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [PesoArchivoValidacion(PesoMaximoEnMegasBytes: 4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}
