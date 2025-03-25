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
}
    
   