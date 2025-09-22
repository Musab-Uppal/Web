using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensibility;
public class MusicDatabase
{
    private string connectionString = "Data Source=localhost;Initial Catalog=Web;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;";
    private SqlConnection connection;
    private void OpenConnection()
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }
    private  void CloseConnection()
    {
        connection.Close();
    }
    public void InsertSong(Song s)
    {
        OpenConnection();
        string query = "INSERT INTO songs (Title, Artist, Duration, Genre, IsLiked, PlayCount) VALUES (@Title, @Artist, @Duration, @Genre, @IsLiked, @PlayCount)";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Title", s.Title);
        command.Parameters.AddWithValue("@Artist", s.Artist);
        command.Parameters.AddWithValue("@Duration", s.Duration);
        command.Parameters.AddWithValue("@Genre", s.Genre);
        command.Parameters.AddWithValue("@IsLiked", s.IsLiked);
        command.Parameters.AddWithValue("@PlayCount", s.PlayCount);
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public void GetAllSongs()
    {
        OpenConnection();
        string query = "select * from Songs";
        SqlCommand cmd = new SqlCommand(query,connection);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.Write($"Id: {reader["SongId"]} Title: {reader["Title"]} Artist: {reader["Artist"]} Genre: {reader["Genre"]} Liked: {reader["IsLiked"]} Duration: {reader["Duration"]} PlayCount: {reader["PlayCount"]}\n");
        }
        CloseConnection();
    }
    public void GetSongCount()
    {
        OpenConnection();
        string query = "select count(*) from songs";
        SqlCommand cmd = new SqlCommand(query,connection);
        Console.Write(cmd.ExecuteScalar());
        CloseConnection();
    }
    public void GetSongById(int id)
    {
        OpenConnection();
        string query = "select * from Songs where SongId =" + id.ToString();
        SqlCommand cmd = new SqlCommand(query,connection);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Console.Write($"Id: {reader["SongId"]} Title: {reader["Title"]} Artist: {reader["Artist"]} Genre: {reader["Genre"]} Liked: {reader["IsLiked"]} Duration: {reader["Duration"]} PlayCount: {reader["PlayCount"]}");
        }
        CloseConnection();
    }
}