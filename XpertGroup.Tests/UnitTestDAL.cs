using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XpertGroup.Datos.DAL;
using XpertGroup.Datos.Entidades;
using XpertGroupIC.DTO;

namespace XpertGroup.Tests
{
    [TestClass]
    public class UnitTestDAL
    {
        [TestMethod]
        public void TestMethod1()
        {
            MatrizDAL matrizDal = new MatrizDAL();
            Parametros parametro = new Parametros() { T = 2, N = 4, M = 5 };
            IPuntoDTO punto;

            var matriz = matrizDal.Inicializar(parametro);

            punto = new IPuntoDTO();
            punto.x = 2;
            punto.y = 2;
            punto.z = 2;
            punto.valor = 4;

            var YYY = matrizDal.UpdateMatriz(punto);

            //Assert.AreEqual();
            var E = 2;
        }
    }
}
