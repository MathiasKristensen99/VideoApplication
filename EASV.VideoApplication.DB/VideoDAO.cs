using System.Collections.Generic;
using System.IO;
using System.Linq;
using EASV.VideoApplication.Models;

namespace EASV.VideoApplication.DB
{
    public class VideoDAO
    {
        public List<Video> GetVideos()
        {
            List<Video> videos = File.ReadAllLines("EASV.VideoApplication.DB/data/MOCK_DATA.csv").Skip(1)
                .Select(v => Video.FromCSV(v)).ToList();
            return videos;
        } 
    }
}