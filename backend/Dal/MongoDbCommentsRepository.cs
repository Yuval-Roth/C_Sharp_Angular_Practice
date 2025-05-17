using MongoDB.Driver;

namespace backend.Dal;

public class MongoDbCommentsRepository
{
    private const string ConnectionString = "mongodb://localhost:27017";
    private const string DatabaseName = "c_sharp_angular_practice";
    private const string CollectionName = "comments";

    public List<Comment> GetAllComments()
    {
        var collection = GetCollection();
        return collection.Find(_ => true).ToList();
    }

    private IMongoCollection<Comment> GetCollection()
    {
        var client = new MongoClient(ConnectionString);
        var database = client.GetDatabase(DatabaseName);
        var collection = database.GetCollection<Comment>(CollectionName);
        return collection;
    }

    public bool AddComment(Comment comment)
    {
        var client = new MongoClient(ConnectionString);
        var database = client.GetDatabase(DatabaseName);
        var collection = database.GetCollection<Comment>(CollectionName);
        
        try
        {
            collection.InsertOne(comment);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}