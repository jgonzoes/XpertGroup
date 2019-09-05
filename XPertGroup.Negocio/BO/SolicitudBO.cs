using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XPertGroup.Negocio.BO
{
    public class SolicitudBO
    {
        public SolicitudBO()
        {
            this.AtributoBO = new List<AtributoBO>();
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
        public List<AtributoBO> AtributoBO { get; set; }
    }
}
