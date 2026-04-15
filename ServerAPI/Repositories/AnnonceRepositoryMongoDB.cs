using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class AnnonceRepositoryMongoDB : IAnnonceRepository
{
    private readonly IMongoCollection<annoncer> _collection;

    public AnnonceRepositoryMongoDB(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDB:ConnectionString"];
        var databaseName = configuration["MongoDB:DatabaseName"];
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<annoncer>("annoncer");
    }

    public List<annoncer> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    public annoncer? GetById(string id)
    {
        return _collection.Find(b => b.annonceId == id).FirstOrDefault();
    }

    public void Add(annoncer annonce)
    {
        _collection.InsertOne(annonce);
    }

    public void Update(annoncer annonce)
    {
        _collection.ReplaceOne(a  => a.annonceId == annonce.annonceId, annonce);
    }

    public void Delete(string id)
    {
        _collection.DeleteOne(b => b.annonceId == id);
    }
}