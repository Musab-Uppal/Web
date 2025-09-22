using System.IO;
public class FileManager
{
    public void SaveSongsToText(List<Song> songs, string filename)
    {
        FileStream file = new FileStream(filename, FileMode.Create);
        StreamWriter writer = new StreamWriter(file);
        foreach (Song s in songs)
        {
            writer.Write(s.ToString());
        }
        writer.Close();
        file.Close();
    }
    public List<Song> LoadSongsFromText(string filename)
    {
        FileStream file = new FileStream(filename, FileMode.Open);
        StreamReader reader = new StreamReader(file);
        List<Song> songs = new List<Song>();
        string song;
        while ((song = reader.ReadLine()) != null)
        {
            string[] data = song.Split(',');
            Song s = new Song(int.Parse(data[0]), data[1], data[2], double.Parse(data[3]), data[4], bool.Parse(data[5]), int.Parse(data[6]));
            songs.Add(s);
        }
        reader.Close();
        file.Close();
        return songs;
    }
}