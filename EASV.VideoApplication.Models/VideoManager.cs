using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace EASV.VideoApplication.Models
{
    public class VideoManager
    {
        public List<Video> GetAllVideos()
        {
            // C:\\GitHub\\VideoApplication\\EASV.VideoApplication.DB\\data\\MOCK_DATA.csv
            
            List<Video> videos = File.ReadAllLines("C:\\GitHub\\VideoApplication\\EASV.VideoApplication.DB\\data\\MOCK_DATA.csv").Skip(1)
                .Select(v => Video.FromCSV(v)).ToList();
            return videos;
        }

        public void CreateNewVideo(Video video)
        {
            List<Video> records = GetAllVideos();

            Video newVideo = new Video();
            newVideo.Id = video.Id;
            newVideo.Name = video.Name;
            newVideo.Release = video.Release;
            newVideo.Storyline = video.Storyline;
            
            records.Add(newVideo);

            var writer =
                new StreamWriter("C:\\GitHub\\VideoApplication\\EASV.VideoApplication.DB\\data\\MOCK_DATA.csv");
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            
            csv.WriteRecords(records);
            writer.Flush();

            //bool append = true;
            //var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            //config.HasHeaderRecord = !append;
            

            //Stream stream = File.Open("C:\\GitHub\\VideoApplication\\EASV.VideoApplication.DB\\data\\MOCK_DATA.csv",
                //FileMode.Append);

            //StreamWriter writer = new StreamWriter(stream);
            //CsvWriter csv = new CsvWriter(writer, config);
            //{
                //csv.WriteField(video.Id);
                //csv.WriteField(video.Name);
                //csv.WriteField(video.Release);
                //csv.WriteField(video.Storyline);
                //csv.WriteRecords(records);
            //}
            
            
            foreach (Video videos in records)
            {
                Console.WriteLine(videos.Id + " " + videos.Name + " " + videos.Release + " " + videos.Storyline);
            }
            
        }
    }
}