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
    public interface IPuntoDTO
    {
        /// <summary>
        /// Posición X
        /// </summary>
        int x { get; set; }
        /// <summary>
        /// Posición Y
        /// </summary>
        int y { get; set; }
        /// <summary>
        /// Posición Z
        /// </summary>
        int z { get; set; }
        /// <summary>
        /// Valor del punto en laMatriz
        /// </summary>
        Int64 valor { get; set; }
    }
}
