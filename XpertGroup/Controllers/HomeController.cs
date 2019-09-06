using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XpertGroup.Validaciones;

namespace XpertGroup.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsumirServicio(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                List<string> data = LeerDatos(file);
                ValidarData.Validar(data);
            }


            return View();
        }

        #region Metodos Privados

        /// <summary>
        /// Lee el archivo para validar la inforacion
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private List<string> LeerDatos(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/archivos/");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var fileName = Path.GetFileName(file.FileName);
            path = Path.Combine(Server.MapPath("~/archivos/"), fileName);
            file.SaveAs(path);

            List<string> datosEnviar = new List<string>();
            string data = System.IO.File.ReadAllText(path);

            foreach (string row in data.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    datosEnviar.Add(row);
                }
            }
            return datosEnviar;
        }
        #endregion


    }
}