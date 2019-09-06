namespace XpertGroupIC.Constntes
{
    /// <summary>
    /// Clase que mantine las constantes del proyecto
    /// </summary>
    public class Constantes
    {
        /// <summary>
        /// Ruta de acceso a donde se va a persistir la matiz
        /// FAVOR DAR ACCESO A ESTA RUTA A LA CUENTA CON LA QUE SE EJECUTA EL PROYECTO
        /// </summary>
        public const string RUTA_ARCHIVO = @"D:\TMP\XpertMatrix.txt";

        public const string ERROR_VALIDACION = "Se encontraron errores de validacion de datos";

        public const string NOMBRE_SERVICIO = "/solicitud";
        public const string SERVICIO_ERROR_400 = "No hay datos para consumir el servicio";
        public const string SERVICIO_ERROR_40X = "Error llamando la Solicitud: ";

        public const string BASE_PATH = "http://localhost/XpertGroupServicio/xpertGroup";

    }
}
