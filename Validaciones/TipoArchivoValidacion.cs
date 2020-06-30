using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Validaciones
{
    public class TipoArchivoValidacion : ValidationAttribute
    {
        private readonly GrupoTipoArchivo grupoTipoArchivo;
        private readonly string[] tiposValidados;

        public TipoArchivoValidacion(string[] tiposValidados)
        {
            this.tiposValidados = tiposValidados;
        }
        public TipoArchivoValidacion(GrupoTipoArchivo grupoTipoArchivo)
        {
            if (grupoTipoArchivo == GrupoTipoArchivo.Imagen) {
                this.tiposValidados = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formFile = value as IFormFile;
            if (formFile == null)
            {
                return ValidationResult.Success;
            }
            // de byte a mb
            if (!tiposValidados.Contains(formFile.ContentType))
            {
                return new ValidationResult($"El tipo de los archivos debe ser uno de los sgtes.: {string.Join(",", tiposValidados)}");
            }
            return ValidationResult.Success;
        }
    }
}
