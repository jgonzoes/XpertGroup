using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XpertGroupIC.DTO;

namespace XpertGroup.Models
{
    public class SolicitudModel
    {
        public SolicitudModel()
        {
            this.Atributo = new List<AtributoModel>();
        }
        /// <summary>
        /// Casos de prueba
        /// </summary>
        /// <value>Casos de prueba</value>
        [Required]
        [Range(1, 50, ErrorMessage = "Las Pruebas no pueden ser menor que 1 ni mayor a 50")]
        public int? T { get; set; }

        /// <summary>
        /// Gets or Sets Operaciones
        /// </summary>
        [Required]
        public List<AtributoModel> Atributo { get; set; }
    }
}