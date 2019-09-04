using System;
using XpertGroup.Datos.DAL;
using XpertGroupIC.Behavior;
using XpertGroupIC.DTO;

namespace XPertGroup.Negocio.BL
{
    /// <summary>
    ///     <decripcion>Clase que hace la logica de negocio de la solucion </decripcion>
    ///     <creacion>
    ///         <fecha>04 Septiembre 2019</fecha>
    ///         <autor>Joaquin Gonzalez E.</autor>
    ///     </creacion>
    /// </summary>
    public class MatrizBL : IMatrixBehavior
    {
        #region Variables Privadas
        /// <summary>
        /// Variablaes de instancia peresosa el DAL
        /// </summary>
        private Lazy<MatrizDAL> _matrizDAL;
        #endregion

        #region Constructor
        public MatrizBL()
        {
            _matrizDAL = new Lazy<MatrizDAL>();
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Metodo que inicaliza la matriz
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public IMatrizDTO Inicializar(IParametrosDTO parametro)
        {
            IMatrizDTO matriz = _matrizDAL.Value.Inicializar(parametro);
            return matriz;
        }

        /// <summary>
        /// Metodo que suma los valors dentro de dos puntos en el cubo
        /// </summary>
        /// <param name="puntoInicial">Punto inicial</param>
        /// <param name="puntoFinal">Punto Final</param>
        /// <returns>La sma de los valores</returns>
        public long QueryMatiz(IPuntoDTO puntoInicial, IPuntoDTO puntoFinal)
        {
            long respuesta = 0;
            IMatrizDTO matriz = this.RecuperarJson();

            for (int i = puntoInicial.x; i <= puntoFinal.x; i++)
            {
                for (int j = puntoInicial.y; j <= puntoFinal.y; j++)
                {
                    for (int k = puntoInicial.z; k <= puntoFinal.z; k++)
                    {
                        respuesta += matriz.Matriz[i, j, k];
                    }
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Trae los datos del archivo guardado
        /// </summary>
        /// <returns></returns>
        public IMatrizDTO RecuperarJson()
        {
            IMatrizDTO matriz = _matrizDAL.Value.RecuperarJson();
            return matriz;
        }

        /// <summary>
        /// Actualiza un punto en la matriz
        /// </summary>
        /// <param name="puntoActualizar"></param>
        /// <returns></returns>
        public IMatrizDTO UpdateMatriz(IPuntoDTO puntoActualizar)
        {
            IMatrizDTO matriz = _matrizDAL.Value.UpdateMatriz(puntoActualizar);
            return matriz;
        }
        #endregion
    }
}
