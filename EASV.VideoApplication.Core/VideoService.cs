using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace EASV.VideoApplication.Models
{
    public class VideoService : IVideoService
    {
        public List<Video> GetAllVideos()
        {
            List<Video> videos = File.ReadAllLines("C:\\GitHub\\VideoApplication\\EASV.VideoApplication.DB\\data\\MOCK_DATA.csv").Skip(1)
                .Select(v => Video.FromCSV(v)).ToList();
            return videos;
        }  

        public Video SearchVideoByName(string name)
        {
            List<Video> videos = GetAllVideos();
            
            foreach (Video video in videos)
            {
                if (video.Name.Contains(name))
                {
                    Console.WriteLine("A video has been found:");
                    Console.WriteLine(video.Id + " " + video.Name);
                    return video;
                }
            }
            return null;
        }

        public void CreateNewVideo(Video video)
        {
            List<Video> records = new List<Video>();

            Video newVideo = new Video();
            newVideo.Id = video.Id;
            newVideo.Name = video.Name;
            newVideo.Release = video.Release;
            newVideo.Storyline = video.Storyline;
            
            records.Add(newVideo);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.HasHeaderRecord = false;
            var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyyy" } };
            
            
            Stream stream = File.Open("C:\\GitHub\\VideoApplication\\EASV.VideoApplication.DB\\data\\MOCK_DATA.csv",
                FileMode.Append);
            
            StreamWriter writer = new StreamWriter(stream);
            CsvWriter csv = new CsvWriter(writer, config);

            {
                csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);
                csv.WriteRecords(records);
            }
            
            writer.Flush();
            
            foreach (Video videos in records)
            {
                Console.WriteLine(videos.Id + " " + videos.Name + " " + videos.Release + " " + videos.Storyline);
            }
        }
    }
}