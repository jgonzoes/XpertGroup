namespace XpertGroupIC.DTO
{
    /// <summary>
    ///     <decripcion>Interfas que trasporta los parametros de la Matiz</decripcion>
    ///     <creacion>
    ///         <fecha>04 Septiembre 2019</fecha>
    ///         <autor>Joaquin Gonzalez E.</autor>
    ///     </creacion>
    /// </summary
    public class IParametrosDTO
    {
        /// <summary>
        /// el número de casos de prueba
        /// </summary>
        public int T { get; set; }
        /// <summary>
        /// Tamaño de la Matriz
        /// </summary>
        public int N { get; set; }
        /// <summary>
        /// M define el número de operaciones. 
        /// </summary>
        public int M { get; set; }
    }
}
