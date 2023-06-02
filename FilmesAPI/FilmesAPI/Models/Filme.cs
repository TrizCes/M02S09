using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo nome não pode exceder 200 caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo diretor é de preenchimento obrigatório")]
        public String Diretor { get; set; }

        [Required(ErrorMessage = "O campo genero é de preenchimento obrigatório")]
        public String Genero { get; set; }
        public int Duracao { get; set; }
    }
}
