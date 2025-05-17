using MongoDB.Bson.Serialization.Attributes;

namespace backend;

public record Comment(
    string Content,
    string Timestamp
)
{
    
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    private string Id { get; set; } = null!;
    
}