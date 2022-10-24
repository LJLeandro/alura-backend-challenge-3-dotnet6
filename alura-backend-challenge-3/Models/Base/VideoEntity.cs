using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace alura_backend_challenge_3.Models.Base
{
    [Table("videos")]
    public class VideoEntity
    {
        [Column("titulo")]
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Column("descricao")]
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Column("url")]
        [StringLength(100)]
        public string URL { get; set; }
    }
}
