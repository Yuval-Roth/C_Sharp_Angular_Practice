using Npgsql;

namespace backend.Dal;

public class CommentsDao
{
    private const string ConnectionString =
        "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=c_sharp_angular_practice";

    public List<Comment> GetAllComments()
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();
        
        var command = new NpgsqlCommand("SELECT content,timestamp FROM comments", connection);
        var reader = command.ExecuteReader();
        var comments = new List<Comment>();
        while (reader.Read())
        {
            var content = reader.GetString(0);
            var timestamp = reader.GetString(1);
            
            comments.Add(new Comment(content,timestamp));
        }

        return comments;
    }
    
    public bool AddComment(Comment comment)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();
        
        var command = new NpgsqlCommand("INSERT INTO comments (content,timestamp) VALUES (@content,@timestamp)", connection);
        command.Parameters.AddWithValue("content", comment.Content);
        command.Parameters.AddWithValue("timestamp", comment.Timestamp);
        return command.ExecuteNonQuery() == 1;
    }
    
}