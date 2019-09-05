using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XPertGroup.Negocio.BO
{
    public class AtributoBO
    {
        public AtributoBO()
        {
            this.Operaciones = new List<OperacionesBO>();
        }
        /// <summary>
        /// Tamaño de la matriz
        /// </summary>
        /// <value>Tamaño de la matriz</value>
        [Required]
        [Range(1, 100, ErrorMessage = "El tamño de la matriz no pueden ser menor que 1 ni mayor a 100")]
        public int? N { get; set; }

        /// <summary>
        /// Número de operadores
        /// </summary>
        /// <value>Número de operadores</value>
        [Required]
        [Range(1, 1000, ErrorMessage = "El numero operaciones no pueden ser menor que 1 ni mayor a 1000")]
        public int? M { get; set; }

        /// <summary>
        /// Gets or Sets Operaciones
        /// </summary>
        [Required]
        public List<OperacionesBO> Operaciones { get; set; }

    }
}
