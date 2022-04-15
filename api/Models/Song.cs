using System;

namespace api.Models
{
    public class Song : IComparable<Song>
    {
        // auto implemented properties
        public int SongID {get; set;}
        public string SongTitle {get; set;}
        public DateTime SongTimestamp {get; set;}
        public string Deleted { get; set; }
        public string Favorited {get; set;}
        public int CompareTo(Song temp) { 
            // since I am using IComparable, I need a CompareTo for "contract"
            return -this.SongTimestamp.CompareTo(temp.SongTimestamp); 
            // negative sign allows the timestamps to be sorted in descending order
        }
    }
}