using System;
using System.Collections.Generic;
using XPertGroup.Negocio.BO;
using XpertGroupIC.DTO;

namespace XPertGroup.Negocio.BL
{
    /// <summary>
    /// Clase qe orquesta la creacion y todo lo que necita para su ejecurcin
    /// </summary>
    public class OperacionBL
    {
        #region objetos de Clase
        private readonly Lazy<MatrizBL> _matrizBL;
        private readonly Lazy<ValidarEntradaBO> _validarEntradaBO;
        private List<long> respuestas;
        #endregion

        #region Constructor
        /// <summary>
        /// Metodo principal que genera la operacion
        /// </summary>
        public OperacionBL()
        {
            _matrizBL = new Lazy<MatrizBL>();
            _validarEntradaBO = new Lazy<ValidarEntradaBO>();
        }
        #endregion

        #region metodos Publicos
        /// <summary>
        /// Metodo que crea la Solicitud
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public List<long> CrearSolicitud(SolicitudBO solicitud)
        {
            bool esCorrecto = false;
            IMatrizDTO matriz;
            respuestas = new List<long>();
            IParametrosDTO parametro;

            esCorrecto = _validarEntradaBO.Value.Validar(solicitud);

            if (esCorrecto)
            {
                foreach (var item in solicitud.AtributoBO)
                {
                    parametro = parametros(item);
                    matriz = _matrizBL.Value.Inicializar(parametro);
                    foreach (var operacion in item.Operaciones)
                    {
                        string operador = operacion.Operacion;
                        String[] evaluar = operador.Split(' ');
                        if (evaluar.Length == 5)
                            matriz = ActulizeMatriz(matriz, operador);
                        else
                        {
                            QueryMatriz(operador);
                        }
                    }
                }
            }
            return respuestas;
        }
        #endregion

        #region metodos Privados
        /// <summary>
        /// Medodo que llana los parametros del atributo para la operacion
        /// </summary>
        /// <param name="atributo"></param>
        /// <returns></returns>
        private IParametrosDTO parametros(AtributoBO atributo)
        {
            IParametrosDTO parametro = new IParametrosDTO();
            parametro.M = atributo.M.Value;
            parametro.N = atributo.N.Value;
            return parametro;
        }

        /// <summary>
        /// Metodo que invoca la actulizacion de un punto en la Matriz
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private IMatrizDTO ActulizeMatriz(IMatrizDTO matriz, string operador)
        {
            int number;
            long valor;
            IPuntoDTO punto = new IPuntoDTO();

            String[] evaluar = operador.Split(' ');
            int.TryParse(evaluar[1], out number);
            punto.x = number;
            int.TryParse(evaluar[2], out number);
            punto.y = number;
            int.TryParse(evaluar[3], out number);
            punto.z = number;
            long.TryParse(evaluar[4], out valor);
            punto.valor = valor;

            matriz = _matrizBL.Value.UpdateMatriz(punto);
            return matriz;
        }

        /// <summary>
        /// Metodo que invoca el query de en la Matriz
        /// </summary>
        /// <param name="operador"></param>
        private void QueryMatriz(string operador)
        {
            int number;
            IPuntoDTO puntoIni = new IPuntoDTO();
            IPuntoDTO puntoFin = new IPuntoDTO();

            String[] evaluar = operador.Split(' ');
            int.TryParse(evaluar[1], out number);
            puntoIni.x = number;
            int.TryParse(evaluar[2], out number);
            puntoIni.y = number;
            int.TryParse(evaluar[3], out number);
            puntoIni.z = number;

            int.TryParse(evaluar[4], out number);
            puntoFin.x = number;
            int.TryParse(evaluar[5], out number);
            puntoFin.y = number;
            int.TryParse(evaluar[6], out number);
            puntoFin.z = number;
            long query = _matrizBL.Value.QueryMatiz(puntoIni, puntoFin);

            respuestas.Add(query);
        }
        #endregion
    }
}
