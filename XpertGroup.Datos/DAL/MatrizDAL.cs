using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using XpertGroupIC.Behavior;
using XpertGroupIC.Constntes;
using XpertGroupIC.DTO;

namespace XpertGroup.Datos.DAL
{
    /// <summary>
    ///     <decripcion>Clase que hace la persistecia de datos </decripcion>
    ///     <creacion>
    ///         <fecha>04 Septiembre 2019</fecha>
    ///         <autor>Joaquin Gonzalez E.</autor>
    ///     </creacion>
    /// </summary>
    public class MatrizDAL : IMatrixBehavior
    {
        #region Metodos Publicos
        /// <summary>
        /// Metodo para Crear la Matriz e inicializa en 0 todos los valores
        /// El valor de N es aumentado en 1 solo para que la matriz sea de 1 a N y no estar restando 1
        /// y se ignora el indice = para todas las posiciones
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Una Matriz inicializada</returns>
        public IMatrizDTO Inicializar(IParametrosDTO parametro)
        {
            Matriz matriz = new Matriz();
            parametro.N++;
            long[,,] matrizAuxiliar = new long[parametro.N, parametro.N, parametro.N];
            matriz.Matriz = matrizAuxiliar;
            inicializa(matriz);
            GuardarJson(matriz);
            return matriz;
        }

        /// <summary>
        /// Metodo que no se implementa en la capa de persistencia
        /// </summary>
        /// <param name="puntoInicial"></param>
        /// <param name="puntoFinal"></param>
        /// <returns></returns>
        public long QueryMatiz(IPuntoDTO puntoInicial, IPuntoDTO puntoFinal)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza el valor en un punto de la matriz
        /// </summary>
        /// <param name="puntoActualizar"></param>
        /// <returns></returns>
        public IMatrizDTO UpdateMatriz(IPuntoDTO puntoActualizar)
        {
            IMatrizDTO matriz = RecuperarJson();
            matriz.Matriz[puntoActualizar.x, puntoActualizar.y, puntoActualizar.z] = puntoActualizar.valor;
            GuardarJson(matriz);
            return matriz;
        }

        /// <summary>
        /// Metodo que recupera el archivo que contiene la matriz
        /// </summary>
        public IMatrizDTO RecuperarJson()
        {
            IMatrizDTO matriz = new IMatrizDTO();
            string filepath = Constantes.rutaArchivo;
            string result = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                var matrizJson = r.ReadToEnd();
                var salida = JsonConvert.DeserializeObject<long[,,]>(matrizJson);
                matriz.Matriz = salida;
                return matriz;
            }
        }
        #endregion

        #region Metodos privados
        /// <summary>
        /// Metodo Privado que inicializa la matriz en ceros
        /// </summary>
        /// <param name="matriz"></param>
        private void inicializa(IMatrizDTO matriz)
        {
            for (int i = 0; i < matriz.Matriz.GetLength(1); i++)
            {
                for (int j = 0; j < matriz.Matriz.GetLength(1); j++)
                {
                    for (int k = 0; k < matriz.Matriz.GetLength(1); k++)
                    {
                        matriz.Matriz[i, j, k] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que guarda el arreglo en formato JSon, se supone que existe la ruta y se tienen los permisos de lectura y escritura
        /// </summary>
        /// <param name="matriz"></param>
        private void GuardarJson(IMatrizDTO matriz)
        {
            string rutaGuardado = Constantes.rutaArchivo;
            string output = JsonConvert.SerializeObject(matriz.Matriz);

            using (StreamWriter writer = File.CreateText(rutaGuardado))
            {
                writer.WriteLine(output);
            }
        }
        
        #endregion
    }
}
