using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhotoBackup
{
    public class PhotoDirectoryAnalyzer
    {
        private Regex _yearRegex = new Regex("^20[\\d]{2}");

		public IEnumerable<Album> GetAlbums(IEnumerable<string> paths)
		{
            var result = new List<Album>();

            foreach (var path in paths)
            {
                Album album = new Album();
                if (!IsIgnored(path))
                {
					album.Year = GetYear(path);
					album.Name = GetAlbumName(path);
                    album.SourcePath = path;
                    result.Add(album);
                }
            }

            return result;
		}

        private bool IsIgnored(string path)
        {
            return Path.GetFileName(path).StartsWith("_");
        }

        private string GetYear(string path)
        {
            Match match = _yearRegex.Match(Path.GetFileName(path));
            return match.Value;
        }

        private string GetAlbumName(string path)
        {
            return Path.GetFileName(path);
        }
    }
}
