namespace ciberinfraestructura_tarea2_webserver_rest.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CatPersonal
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(80)")]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(80)")]
        public string cargo { get; set; } = string.Empty;
    }
}