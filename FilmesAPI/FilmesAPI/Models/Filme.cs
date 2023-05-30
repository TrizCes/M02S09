using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Diretor { get; set; }
        public String Genero { get; set; }
        public int Duracao { get; set; }
    }
}
