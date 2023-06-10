using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.DTO
{
    public class FilmeDiretorDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdFilme { get; set; }

        [Required]
        public int IdDiretor { get; set; }
    }
}
