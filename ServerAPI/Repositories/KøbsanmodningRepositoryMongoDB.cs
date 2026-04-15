using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class KøbsanmodningRepositoryMongoDB : IKøbsanmodningRepository
{
    private readonly IMongoCollection<købsanmodninger> _collection;

    public KøbsanmodningRepositoryMongoDB(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDB:ConnectionString"];
        var databaseName = configuration["MongoDB:DatabaseName"];
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<købsanmodninger>("købsanmodninger");
    }

    public List<købsanmodninger> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    public købsanmodninger? GetById(string id)
    {
        return _collection.Find(k => k.købsanmodningID == id).FirstOrDefault();
    }

    public void Add(købsanmodninger købsanmodning)
    {
        _collection.InsertOne(købsanmodning);
    }

    public void Update(købsanmodninger købsanmodning)
    {
        _collection.ReplaceOne(k => k.købsanmodningID == købsanmodning.købsanmodningID, købsanmodning);
    }

    public void Delete(string id)
    {
        _collection.DeleteOne(k => k.købsanmodningID == id);
    }
}
