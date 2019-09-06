using System.Collections.Generic;

namespace XpertGroup.Models
{
    public class SalidaModel
    {
        public SalidaModel()
        {
            this.resultados = new List<string>(); 
        }
        public List<string> resultados { get; set; }
    }
}