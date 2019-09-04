namespace XpertGroupIC.Behavior
{
    /// <summary>
    ///     <decripcion>Interfas que trasporta la Matiz</decripcion>
    ///     <creacion>
    ///         <fecha>04 Septiembre 2019</fecha>
    ///         <autor>Joaquin Gonzalez E.</autor>
    ///     </creacion>
    /// </summary
    public interface IMatrizDTO
    {
        /// <summary>
        /// Matriz que va a ser trasportada
        /// </summary>
        int[,,] Matriz { get; set; }
    }
}