using System;
using System.Collections.Generic;

class Program
{
    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Length > 200)
                throw new ArgumentException("Judul video tidak boleh kosong dan maksimal 200 karakter.");

            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            if (count < 0 || count > 25000000)
                throw new ArgumentException("Play count harus positif dan maksimal 25.000.000.");

            try
            {
                checked { this.playCount += count; }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Terjadi overflow saat menambahkan play count.");
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID Video: {id}");
            Console.WriteLine($"Judul: {title}");
            Console.WriteLine($"Jumlah Play: {playCount}");
        }

        public int GetPlayCount()
        {
            return playCount;
        }

        public string GetTitle()
        {
            return title;
        }
    }

    class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public string Username { get; private set; }

        public SayaTubeUser(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 100)
                throw new ArgumentException("Username tidak boleh kosong dan maksimal 100 karakter.");

            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public void AddVideo(SayaTubeVideo video)
        {
            if (video == null)
                throw new ArgumentNullException("Video tidak boleh kosong.");

            if (video.GetPlayCount() >= int.MaxValue)
                throw new ArgumentException("Play count video melebihi batas integer maksimum.");

            uploadedVideos.Add(video);
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (SayaTubeVideo video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            int printLimit = Math.Min(8, uploadedVideos.Count);
            for (int i = 0; i < printLimit; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Masukkan username Anda: ");
        string username = Console.ReadLine();

        SayaTubeUser user = new SayaTubeUser(username);

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"Masukkan judul video {i}: ");
            string judulVideo = Console.ReadLine();

            SayaTubeVideo video = new SayaTubeVideo(judulVideo);
            video.IncreasePlayCount(1000);
            user.AddVideo(video);
        }

        user.PrintAllVideoPlaycount();
        Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");
    }
}
