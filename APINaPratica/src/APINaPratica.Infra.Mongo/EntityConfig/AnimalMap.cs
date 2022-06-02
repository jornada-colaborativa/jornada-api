using APINaPratica.Domain.Entities.Animal;
using MongoDB.Bson.Serialization;

namespace APINaPratica.Infra.Mongo.EntityConfig
{
    public class AnimalMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Animal>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Cadastro).SetIsRequired(true);
                map.MapMember(x => x.Atualizacao).SetIsRequired(true);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Apelido).SetIsRequired(true);
                map.MapMember(x => x.CorPredominante).SetIsRequired(true);
                map.MapMember(x => x.Nascimento).SetIsRequired(true);
                map.MapMember(x => x.Porte).SetIsRequired(true);
                map.MapMember(x => x.Raca).SetIsRequired(true);
            });
        }
    }
}