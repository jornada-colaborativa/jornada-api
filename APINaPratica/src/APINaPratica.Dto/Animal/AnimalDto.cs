using APINaPratica.Dto.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace APINaPratica.Dto.Animal
{
    public class AnimalDto : BaseDto
    {
        [SwaggerSchema("Nome do animal.")]
        public String Nome { get; set; }
        [SwaggerSchema("Apelido do animal.")]
        public String Apelido { get; set; }
        [SwaggerSchema("Raça do animal.")]
        public String Raca { get; set; }
        [SwaggerSchema("CorPredominante do animal.")]
        public String CorPredominante { get; set; }
        [SwaggerSchema("Nascimento do animal.")]
        public DateTime Nascimento { get; set; }
        [SwaggerSchema("Porte do animal.")]
        public String Porte { get; set; }
    }
}
