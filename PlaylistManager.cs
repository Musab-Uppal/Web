public class PlaylistManager
{
    private List<Song> AllSongs;
    private string PlaylistName;
    private int MaxSongs;
    public PlaylistManager( string n = "",int ms = 10)
    {
        AllSongs = new List<Song>();
        MaxSongs = ms;
        PlaylistName = n;
    }
    public void AddMultipleSongs(params Song[] songs)
    {
        for (int i = 0; i < songs.Length; i++)
        {
            AllSongs.Add(songs[i]);
        }
    }
    public void CreatePlaylist(string name, int maxSongs = 10)
    {
        PlaylistName = name;
        MaxSongs = maxSongs;
    }
    public List<Song> FindSongsByGenre(string genre)
    {
        List<Song> songs = new List<Song>();
        foreach (Song s in AllSongs)
        {
            if (s.Genre==genre)
            {
                songs.Add(s);
            }
        }
        return songs;
    }
    public void GetPlaylistStatistics()
    {
        double Duration = 0;
        int liked = 0;
        foreach (Song s in AllSongs)
        {
            Duration += s.Duration;
            if (s.IsLiked)
            {
                liked++;
            }
        }
        Console.Write($"Total Songs: {AllSongs.Count} Total Duration: {Duration} Liked Songs: {liked} ");
     }
}