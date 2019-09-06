using System.Collections.Generic;

namespace XpertGroupIC.DTO
{
    public class IAtributoDTO
    {
        public IAtributoDTO()
        {
            this.Operaciones = new List<IOperacionesDTO>();
        }
        /// <summary>
        /// Tamaño de la matriz
        /// </summary>
        /// <value>Tamaño de la matriz</value>
        public int? N { get; set; }

        /// <summary>
        /// Número de operadores
        /// </summary>
        /// <value>Número de operadores</value>
        public int? M { get; set; }

        /// <summary>
        /// Gets or Sets Operaciones
        /// </summary>
        public List<IOperacionesDTO> Operaciones { get; set; }
    }
}
