using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class FilmeDiretor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Filme")]
        public int IdFilme { get; set; }
        public Filme Filme { get; set; }

        [ForeignKey("Diretor")]
        public int IdDiretor { get; set; }
        public Diretor Diretor { get; set; }
    }
}
