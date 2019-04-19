using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoBackup
{
    public class Program
    {
        static void Main(string[] args)
        {
            var photoDirectoryAnalyzer = new PhotoDirectoryAnalyzer();
            var directories = Directory.GetDirectories(".");

            IEnumerable<Album> albums = photoDirectoryAnalyzer.GetAlbums(directories);

            foreach (var target in args) 
            {
                foreach (var album in albums)
                {
                    CopyAlbum(album, target);
                }
                //DeleteAlbum(album);
            }
        }

        private static void DeleteAlbum(Album album)
        {
            Directory.Delete(album.SourcePath, true);
        }

        private static void CopyAlbum(Album album, string destinationPath)
        {
            if (!album.IsDateless)
            {
                destinationPath = Path.Combine(destinationPath, album.Year);
            }

            destinationPath = Path.Combine(destinationPath, album.Name);

            if(!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            foreach (string newPath in Directory.GetFiles(album.SourcePath, "*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(album.SourcePath, destinationPath), false);
                Console.WriteLine($"Copying file: \r\n {newPath} to \r\n {newPath.Replace(album.SourcePath, destinationPath)}");
			}
        }
    }
}
