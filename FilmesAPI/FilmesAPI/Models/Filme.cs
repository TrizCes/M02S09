using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo nome não pode exceder 200 caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo diretor é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo diretor não pode exceder 200 caracteres")]
        public String Diretor { get; set; }

        [Required(ErrorMessage = "O campo genero é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo genero não pode exceder 200 caracteres")]
        public String Genero { get; set; }

        [Required]
        public int Duracao { get; set; }
    }
}
