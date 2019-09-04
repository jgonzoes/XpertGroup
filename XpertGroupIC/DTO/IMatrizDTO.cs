namespace XpertGroupIC.Behavior
{
    /// <summary>
    ///     <decripcion>Interfas que trasporta la Matiz</decripcion>
    ///     <creacion>
    ///         <fecha>04 Septiembre 2019</fecha>
    ///         <autor>Joaquin Gonzalez E.</autor>
    ///     </creacion>
    /// </summary
    public class IMatrizDTO
    {
        /// <summary>
        /// Matriz que va a ser trasportada
        /// </summary>
       public long[,,] Matriz { get; set; }
    }
}