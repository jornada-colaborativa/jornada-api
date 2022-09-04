using APINaPratica.Infra.Mongo.EntityConfig;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace APINaPratica.Infra.Mongo.Persistence
{
    /// <summary>
    /// responsável configuração e inicialização da persistência 
    /// e mapeamento dos objetos no repositório.
    /// </summary>
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            AnimalMap.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
