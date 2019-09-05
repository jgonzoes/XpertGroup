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

            if (solicitud.T != solicitud.AtributoBO.Count)
                esValido = false;

            foreach (var item in solicitud.AtributoBO)
            {
                if (item.Operaciones.Count != item.N)
                    esValido = false;
                foreach (var operacion in item.Operaciones)
                {
                    string operador = operacion.Operacion;
                    String[] evaluar = operador.Split(' ');

                    if ((evaluar.Length == 5 || evaluar.Length == 7))
                    {
                        if (evaluar.Length == 5)
                            esValido = validarUpDate(evaluar, item.N.Value);
                        else
                            esValido = validarQuery(evaluar, item.N.Value);
                    }
                    else
                        esValido = false;
                }
            }
            return esValido;
        }

        private bool validarUpDate(String[] dato, long maximo)
        {
            bool esValido = true;
            long number;
            try
            {
                if (dato[0] != "UPDATE")
                    esValido = false;

                for (int i = 1; i < 4; i++)
                {
                    esValido = long.TryParse(dato[i], out number);
                    esValido = validaValor(number, maximo);
                }

                esValido = long.TryParse(dato[4], out number);
                if (number > Math.Pow(10, 9))
                    esValido = false;
            }
            catch (Exception)
            {
                esValido = false;
            }
            return esValido;
        }

        private bool validarQuery(String[] dato, long maximo)
        {
            bool esValido = true;
            long number, number2;
            try
            {
                if (dato[0] != "QUERY")
                    esValido = false;

                for (int i = 1; i < 7; i++)
                {
                    esValido = long.TryParse(dato[i], out number);
                    esValido = validaValor(number, maximo);
                }

                for (int i = 1; i < 4; i++)
                {
                    esValido = long.TryParse(dato[i], out number);
                    esValido = long.TryParse(dato[i + 3], out number2);
                    if (number > number2)
                        esValido = false;
                }
            }
            catch (Exception)
            {
                esValido = false;
            }
            return esValido;
        }

        private bool validaValor(long evaluado, long maximo)
        {
            bool esValido = true;
            if (evaluado > maximo || evaluado < 1)
                esValido = false;
            return esValido;
        }
    }
}
