using System;

class Program
{
    static void Main()
    {
        List<Song> songs = new List<Song>();
        FileManager manager = new FileManager();
        MusicDatabase db = new MusicDatabase();
        PlaylistManager playlistManager = new PlaylistManager();
        int choice;
        do
        {
            Console.WriteLine("\n--- Song Manager ---");
            Console.WriteLine("1. Create Songs");
            Console.WriteLine("2. Display All Songs");
            Console.WriteLine("3. Save Songs to Text File");
            Console.WriteLine("4. Load Songs from Text File");
            Console.WriteLine("5. Insert Songs into Database");
            Console.WriteLine("6. Display All Songs from Database");
            Console.WriteLine("7. Get Song by ID (Database)");
            Console.WriteLine("8. Get Total Song Count (Database)");
            Console.WriteLine("9. Create Playlist");
            Console.WriteLine("10. Display Playlist Statistics");
            Console.WriteLine("11. Find Songs by Genre (Playlist)");
            Console.WriteLine("12. Play a Song (increase PlayCount)");
            Console.WriteLine("13. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("How many songs do you want to add? ");
                    int count = int.Parse(Console.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"\nEnter details for Song #{i + 1}");

                        Console.Write("Song ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Artist: ");
                        string artist = Console.ReadLine();

                        Console.Write("Duration: ");
                        double duration = double.Parse(Console.ReadLine());

                        Console.Write("Genre: ");
                        string genre = Console.ReadLine();

                        Console.Write("Is Liked (true/false): ");
                        bool isLiked = bool.Parse(Console.ReadLine());

                        Console.Write("Play Count: ");
                        int playCount = int.Parse(Console.ReadLine());
                        Song song = new Song(id, title, artist, duration, genre, isLiked, playCount);
                        songs.Add(song);
                    }
                    Console.WriteLine("Songs added successfully.");
                    break;
                case 2:
                    Console.WriteLine("\n--- All Songs ---");
                    foreach (Song s in songs)
                    {
                        Console.WriteLine(s.DisplaySongInfo());
                    }
                    break;

                case 3:
                    manager.SaveSongsToText(songs, "songs.txt");
                    Console.WriteLine("Songs saved to songs.txt");
                    break;

                case 4:
                    songs = manager.LoadSongsFromText("songs.txt");
                    Console.WriteLine("Songs loaded from songs.txt");
                    break;

                case 5:
                    foreach (Song s in songs)
                    {
                        db.InsertSong(s);
                    }
                    Console.WriteLine("Songs inserted into database.");
                    break;

                case 6:
                    db.GetAllSongs();
                    break;

                case 7:
                    Console.Write("Enter Song ID: ");
                    int songId = int.Parse(Console.ReadLine());
                    db.GetSongById(songId);
                    break;

                case 8:
                    db.GetSongCount();
                    break;

                case 9:
                    Console.WriteLine("Enter name for playlist");
                    string name = Console.ReadLine();
                    playlistManager.CreatePlaylist(name);
                    foreach (Song s in songs)
                    {
                        playlistManager.AddMultipleSongs(s);
                    }
                    Console.WriteLine("Playlist created.");
                    break;

                case 10:
                    playlistManager.GetPlaylistStatistics();
                    break;

                case 11:
                    Console.Write("Enter Genre: ");
                    string searchGenre = Console.ReadLine();
                    List<Song> foundSongs = playlistManager.FindSongsByGenre(searchGenre);
                    Console.WriteLine("\n--- Songs in Genre ---");
                    foreach (Song s in foundSongs)
                    {
                        Console.WriteLine(s.DisplaySongInfo());
                    }
                    break;

                case 12:
                    Console.Write("Enter Song ID to play: ");
                    int playId = int.Parse(Console.ReadLine());
                    Song songToPlay = songs.Find(s => s.SongId == playId);
                    if (songToPlay != null)
                    {
                        songToPlay.PlayCount++;
                        Console.WriteLine($"Played {songToPlay.Title}. PlayCount now {songToPlay.PlayCount}.");
                    }
                    else
                    {
                        Console.WriteLine("Song not found in memory.");
                    }
                    break;

                case 13:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 13);
    }
}
