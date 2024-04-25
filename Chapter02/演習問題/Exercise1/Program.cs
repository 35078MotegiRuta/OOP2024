using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {
            //2.1.3
            var songs = new Song[] {
                new Song("多分、風。","サカナクション",294),
                new Song("traveling","宇多田ヒカル",317),
                new Song("群青日和","東京事変",213),


            };
            PrintSongs(songs);
        }


        //2.1.4
        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {
                Console.WriteLine(@"{0},{1},{2:mm\:ss}",song.Title,song.ArtistName,
                                                        TimeSpan.FromSeconds(song.Length));
        } }
    }
}
