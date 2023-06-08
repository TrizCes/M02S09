using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Diretor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage="Este campo aceita até 200 caracteres")]
        [MinLength(3, ErrorMessage = "Favor digitar o nome do diretor")]
        public String Nome { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        [MinLength(3, ErrorMessage = "Favor digitar o telefone do diretor")]
        public String Telefone { get; set; }
    }
}
