using System;
using System.Runtime.InteropServices;

namespace EASV.VideoApplication.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }
        public string Storyline { get; set; }

        public static Video FromCSV(string csvLine)
        {
            string[] videos = csvLine.Split(',');
            Video video = new Video();
            video.Id = Convert.ToInt32(videos[0]);
            video.Name = Convert.ToString(videos[1]);
            video.Release = Convert.ToDateTime(videos[2]);
            video.Storyline = Convert.ToString(videos[3]);
            return video;
        }
    }
}