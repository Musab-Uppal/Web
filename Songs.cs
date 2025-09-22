public class Song
{
     private int songId;
    private string title;
    private string artist;
    private double duration;
    private string genre;
    private bool isLiked;
    private int playCount;

    public int SongId
    {
        get { return songId; }
        set { songId = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Artist
    {
        get { return artist; }
        set { artist = value; }
    }

    public double Duration
    {
        get { return duration; }
        set { duration = value; }
    }

    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    public bool IsLiked
    {
        get { return isLiked; }
        set { isLiked = value; }
    }

    public int PlayCount
    {
        get { return playCount; }
        set { playCount = value; }
    }
    public Song(int id, string t, string art, double d, string gen, bool liked = false, int c = 0)
    {
        SongId = id;
        Title = t;
        Artist = art;
        Duration = d;
        Genre = gen;
        IsLiked = liked;
        PlayCount = c;
    }
    public void PlaySong()
    {
        PlayCount++;
    }
    public string DisplaySongInfo()
    {
        return $"Id: {SongId}, Title: {Title}, Artist: {Artist},Duration: {Duration}, Genre: {Genre},   Liked: {IsLiked}, PlayCount: {PlayCount}\n";
    }

    public override string ToString()
    {
         return $"{SongId},{Title},{Artist},{Duration},{Genre},{IsLiked},{PlayCount}\n";
    }
}