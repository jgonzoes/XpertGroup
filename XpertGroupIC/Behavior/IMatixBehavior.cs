using System;
using XpertGroupIC.DTO;

namespace XpertGroupIC.Behavior
{
    /// <summary>
    ///     <decripcion>Interfas que muestra los metodos a implementar de la Matiz</decripcion>
    ///     <creacion>
    ///         <fecha>04 Septiembre 2019</fecha>
    ///         <autor>Joaquin Gonzalez E.</autor>
    ///     </creacion>
    /// </summary>
    public interface IMatrixBehavior
    {
        /// <summary>
        /// Inicializa la matriz siendo un cubo e tamaño N
        /// </summary>
        /// <param name="parametro"><see cref="IParametrosDTO"/> con los parametros para la Matiz </param>
        /// <returns><see cref="IMatrizDTO"/> Con la Matriz creada e inicializada</returns>
        IMatrizDTO Inicializar(IParametrosDTO parametro);

        /// <summary>
        /// Actualiza una posición de la matriz con un valor dado en <see cref="IPuntoDTO"/>
        /// </summary>
        /// <param name="puntoActualizar"><see cref="IPuntoDTO"/> con los inidces del punto y el valor </param>
        /// <returns><see cref="IMatrizDTO"/> Con la Matriz actualizada</returns>
        IMatrizDTO UpdateMatriz(IPuntoDTO puntoActualizar);

        /// <summary>
        /// Hace la suma entre dos puntos de la matriz
        /// </summary>
        /// <param name="puntoInicial"></param>
        /// <param name="puntoFinal"></param>
        /// <returns>Valor de la suma de los valores de la Matirz entre dos puntos</returns>
        Int64 QueryMatiz(IPuntoDTO puntoInicial, IPuntoDTO puntoFinal);
    }
}
