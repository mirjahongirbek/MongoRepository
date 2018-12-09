using MongoDB.Driver;

namespace MongoRepository.Interface
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; set; }
    }
}
