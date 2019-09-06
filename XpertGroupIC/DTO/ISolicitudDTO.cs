using System.Collections.Generic;

namespace XpertGroupIC.DTO
{
    public class ISolicitudDTO
    {
        public ISolicitudDTO()
        {
            this.AtributoBO = new List<IAtributoDTO>();
        }
        /// <summary>
        /// Casos de prueba
        /// </summary>
        /// <value>Casos de prueba</value>
        public int? T { get; set; }

        /// <summary>
        /// Gets or Sets Operaciones
        /// </summary>
        public List<IAtributoDTO> AtributoBO { get; set; }
    }
}
