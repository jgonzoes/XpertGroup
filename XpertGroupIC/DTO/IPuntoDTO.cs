using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpertGroupIC.DTO
{
    /// <summary>
    ///     <decripcion>Interfas que trasporta un punto en la Matriz</decripcion>
    ///     <creacion>
    ///         <fecha>04 Septiembre 2019</fecha>
    ///         <autor>Joaquin Gonzalez E.</autor>
    ///     </creacion>
    /// </summary
    public class IPuntoDTO
    {
        /// <summary>
        /// Posición X
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// Posición Y
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// Posición Z
        /// </summary>
        public int z { get; set; }
        /// <summary>
        /// Valor del punto en laMatriz
        /// </summary>
        public long valor { get; set; }
    }
}
