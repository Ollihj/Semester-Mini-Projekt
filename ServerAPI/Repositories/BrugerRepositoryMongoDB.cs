using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class BrugerRepositoryMongoDB : IBrugerRepository
{
    private readonly IMongoCollection<bruger> _collection;

    public BrugerRepositoryMongoDB(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDB:ConnectionString"];
        var databaseName = configuration["MongoDB:DatabaseName"];
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<bruger>("brugere");
    }

    public List<bruger> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    public bruger? GetById(string id)
    {
        return _collection.Find(b => b.brugerID == id).FirstOrDefault();
    }

    public void Add(bruger bruger)
    {
        _collection.InsertOne(bruger);
    }

    public void Update(bruger bruger)
    {
        _collection.ReplaceOne(b => b.brugerID == bruger.brugerID, bruger);
    }

    public void Delete(string id)
    {
        _collection.DeleteOne(b => b.brugerID == id);
    }
}
