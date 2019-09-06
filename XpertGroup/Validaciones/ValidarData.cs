using System;
using System.Collections.Generic;
using XpertGroup.Models;

namespace XpertGroup.Validaciones
{
    public static class ValidarData
    {
        public static SolicitudModel Validar(List<string> data)
        {
            bool dosArgumentos = false;
            SolicitudModel solicitud = new SolicitudModel();
            List<OperacionesModel> operaciones = new List<OperacionesModel>();

            AtributoModel atributo = new AtributoModel();

            int T = 0, M = 0, N = 0, MAuxiliar = 0;
            int totalErroes = 0;

            for (int i = 0; i < data.Count; i++)
            {
                if (i == 0)
                {
                    if (int.TryParse(data[i], out T))
                    {
                        dosArgumentos = true;
                        solicitud.T = T;
                    }
                    else
                        totalErroes++;
                    i++;
                }
                
                if (dosArgumentos)
                {
                    atributo = new AtributoModel();
                    operaciones = new List<OperacionesModel>();
                    String[] evaluar = data[i].Split(' ');
                    if (int.TryParse(evaluar[0], out N))
                    {
                        dosArgumentos = false;
                        MAuxiliar = 0;
                        if (!(int.TryParse(evaluar[1], out M)))
                            totalErroes++;
                        atributo.M = M;
                        atributo.N = N;
                    }
                    else
                        totalErroes++;
                    
                }
                else
                {
                    OperacionesModel operacion = new OperacionesModel();
                    String[] evaluar = data[i].Split(' ');
                    if ((evaluar.Length == 5 || evaluar.Length == 7))
                    {
                        if (evaluar.Length == 5)
                            totalErroes += validarUpDate(evaluar, N);
                        else
                            totalErroes += validarQuery(evaluar, N);
                    }
                    operacion.Operacion = data[i];
                    operaciones.Add(operacion);
                    atributo.Operaciones = operaciones;


                    MAuxiliar++;
                    if (MAuxiliar == M)
                    {
                        dosArgumentos = true;
                        solicitud.Atributo.Add(atributo);
                    }
                }
            }

            return solicitud;
        }


        private static int validarUpDate(String[] dato, long maximo)
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

        private static int validarQuery(String[] dato, long maximo)
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

        private static int validaValor(long evaluado, long maximo)
        {
            int totalErrores = 0;
            if (evaluado > maximo || evaluado < 1)
                totalErrores++;
            return totalErrores;
        }
    }
}