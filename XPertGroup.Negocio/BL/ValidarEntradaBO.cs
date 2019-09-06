using System;
using XPertGroup.Negocio.BO;

namespace XPertGroup.Negocio.BL
{
    /// <summary>
    /// Clase que valida la integridad de los datos segun la regla de entrada
    /// 1 <= T <= 50 
    /// 1 <= N <= 100 
    /// 1 <= M <= 1000 
    /// 1 <= x1 <= x2 <= N 
    /// 1 <= y1 <= y2 <= N 
    /// 1 <= z1 <= z2< = N 
    /// 1 <= x, y, z <= N 
    /// -10 9 <= W <= 10 9
    /// </summary>
    public class ValidarEntradaBO
    {
        public bool Validar(SolicitudBO solicitud)
        {
            bool esValido = true;
            int totalErrores = 0;

            if (solicitud.T != solicitud.AtributoBO.Count)
                totalErrores++;

            foreach (var item in solicitud.AtributoBO)
            {
                if (item.Operaciones.Count != item.M)
                    totalErrores++;
                foreach (var operacion in item.Operaciones)
                {
                    string operador = operacion.Operacion;
                    String[] evaluar = operador.Split(' ');

                    if ((evaluar.Length == 5 || evaluar.Length == 7))
                    {
                        if (evaluar.Length == 5)
                            totalErrores += validarUpDate(evaluar, item.N.Value);
                        else
                            totalErrores += validarQuery(evaluar, item.N.Value);
                    }
                    else
                        totalErrores++;
                }
            }

            if (totalErrores > 0)
                esValido = false;

            return esValido;
        }

        private int validarUpDate(String[] dato, long maximo)
        {
            bool esValido = true;
            int totalErrores = 0;

            long number;
            try
            {
                if (dato[0] != "UPDATE")
                    totalErrores++;

                for (int i = 1; i < 4; i++)
                {
                    esValido = long.TryParse(dato[i], out number);
                    totalErrores += validaValor(number, maximo);
                }

                esValido = long.TryParse(dato[4], out number);
                if (number > Math.Pow(10, 9))
                    totalErrores++;
            }
            catch (Exception)
            {
                totalErrores++;
            }

            return totalErrores;
        }

        private int validarQuery(String[] dato, long maximo)
        {
            bool esValido = true;
            int totalErrores = 0;
            long number, number2;
            try
            {
                if (dato[0] != "QUERY")
                    totalErrores++;

                for (int i = 1; i < 7; i++)
                {
                    if (long.TryParse(dato[i], out number))
                        totalErrores += validaValor(number, maximo);
                    else
                        totalErrores++;
                }

                for (int i = 1; i < 4; i++)
                {
                    esValido = long.TryParse(dato[i], out number);
                    esValido = long.TryParse(dato[i + 3], out number2);
                    if (number > number2)
                        totalErrores++;
                }
            }
            catch (Exception)
            {
                totalErrores++;
            }
            return totalErrores;
        }

        private int validaValor(long evaluado, long maximo)
        {
            int totalErrores = 0;
            if (evaluado > maximo || evaluado < 1)
                totalErrores++;
            return totalErrores;
        }
    }
}
