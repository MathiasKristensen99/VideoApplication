using System;
using System.Collections.Generic;

namespace EASV.VideoApplication.Models
{
    public interface IVideoService
    {
        List<Video> GetAllVideos();

        void CreateNewVideo(Video video);

        Video SearchVideoByName(String name);
    }
}