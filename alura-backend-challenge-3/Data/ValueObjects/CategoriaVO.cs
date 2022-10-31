using alura_backend_challenge_3.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace alura_backend_challenge_3.Data.ValueObjects
{
    public class CategoriaVO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Cor { get; set; }

        public ICollection<VideoVO>? Videos { get; set; }
    }
}
