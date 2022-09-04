
/*Namespace que estará contida a classe dentro da aplicação*/
namespace APINaPratica.Domain.Entities.Animal
{
    /// <summary>
    /// Classe animal que representa de forma simples um animal.
    /// 
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Id que é utilizado no repositório de dados como o código 
        /// unico que representa este animal.
        /// </summary>
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
