using System;
using System.Collections.Generic;

namespace EASV.VideoApplication.Models.IServices
{
    public interface IVideoService
    {
        List<Video> GetAllVideos();

        void CreateNewVideo(Video video);

        Video SearchVideoByName(String name);

        void DeleteVideo(int id);

        void UpdateVideo(Video video);
    }
}