using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alura_backend_challenge_3.Models.Base
{
    [Table("categorias")]
    public class CategoriaEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Cor { get; set; }

        public ICollection<VideoEntity> Videos { get; set; }
    }
}
