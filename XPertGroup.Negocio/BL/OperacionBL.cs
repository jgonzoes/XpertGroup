using System;
using System.Collections.Generic;
using XPertGroup.Negocio.BO;
using XpertGroupIC.DTO;

namespace XPertGroup.Negocio.BL
{
    public class OperacionBL
    {
        private readonly Lazy<MatrizBL> _matrizBL;
        private readonly Lazy<ValidarEntradaBO> _validarEntradaBO;
        private List<long> respuestas;

        public OperacionBL()
        {
            _matrizBL = new Lazy<MatrizBL>();
            _validarEntradaBO = new Lazy<ValidarEntradaBO>();
        }

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

        private IParametrosDTO parametros(AtributoBO atributo)
        {
            IParametrosDTO parametro = new IParametrosDTO();
            parametro.M = atributo.M.Value;
            parametro.N = atributo.N.Value;
            return parametro;
        }

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
            long.TryParse(evaluar[3], out valor);
            punto.valor = valor;

            matriz = _matrizBL.Value.UpdateMatriz(punto);
            return matriz;
        }

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

    }
}
