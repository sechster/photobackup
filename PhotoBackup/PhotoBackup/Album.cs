using System;
namespace PhotoBackup
{
    public class Album
    {
        public string SourcePath { get; set; }

        public string Year { get; set; }

        public string Name { get; set; }

		public bool IsDateless 
        { 
            get
            {
                return string.IsNullOrEmpty(Year);
            }
        }
    }
}
