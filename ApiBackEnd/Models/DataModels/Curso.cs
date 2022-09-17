using System.ComponentModel.DataAnnotations;

namespace ApiBackEnd.Models.DataModels
{
    public enum Nivel
    {
        Basico,
        Intermedio,
        Avanzado
    }

    public class Curso: BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        [MaxLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Objetivos { get; set; } = string.Empty;
        public string Requisitos { get; set; } = string.Empty;
        public Nivel Level { get; set; }
    }
}
