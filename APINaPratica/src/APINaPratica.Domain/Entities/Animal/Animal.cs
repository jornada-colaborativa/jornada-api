using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINaPratica.Domain.Entities.Animal
{
    public class Animal
    {
        public Guid Id { get; set; }
        public DateTime Atualizacao { get; set; }
        public DateTime Cadastro { get; set; }
        public String Nome { get; set; }
        public String Apelido { get; set; }
        public String Raca { get; set; }
        public String CorPredominante { get; set; }
        public DateTime Nascimento { get; set; }
        public String Porte { get; set; }
    }
}
