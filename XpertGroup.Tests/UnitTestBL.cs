using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPertGroup.Negocio.BL;
using XpertGroupIC.DTO;

namespace XpertGroup.Tests
{
    [TestClass]
    public class UnitTestBL
    {
        [TestMethod]
        public void TestMethod1()
        {
            IPuntoDTO pIni, pFin, pUpdate;
            MatrizBL matrizBL = new MatrizBL();
            long respuesta = 0;

            pIni = new IPuntoDTO();
            pFin = new IPuntoDTO();
            pUpdate = new IPuntoDTO();

            //QUERY 1 1 1 3 3 3
            pIni.x = 1;
            pIni.y = 1;
            pIni.z = 1;
            
            pFin.x = 3;
            pFin.y = 3;
            pFin.z = 3;

            respuesta = matrizBL.QueryMatiz(pIni, pFin);
            Assert.AreEqual(4, respuesta);

            //UPDATE 1 1 1 23
            pUpdate.x = 1;
            pUpdate.y = 1;
            pUpdate.z = 1;
            pUpdate.valor = 23;
            matrizBL.UpdateMatriz(pUpdate);

            //QUERY 2 2 2 4 4 4
            pIni.x = 2;
            pIni.y = 2;
            pIni.z = 2;

            pFin.x = 4;
            pFin.y = 4;
            pFin.z = 4;

            respuesta = matrizBL.QueryMatiz(pIni, pFin);
            Assert.AreEqual(4, respuesta);

            //QUERY 1 1 1 3 3 3
            pIni.x = 1;
            pIni.y = 1;
            pIni.z = 1;

            pFin.x = 3;
            pFin.y = 3;
            pFin.z = 3;

            respuesta = matrizBL.QueryMatiz(pIni, pFin);
            Assert.AreEqual(27, respuesta);

        }
    }
}
