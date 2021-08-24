using System;
using System.Collections.Generic;
using EASV.VideoApplication.Models;

namespace EASV.VideoApplication.Domain.IRepositories
{
    public interface IVideoRepository
    {
        List<Video> GetAllVideos();

        void CreateNewVideo(Video video);

        Video SearchVideoByName(String name);

        void DeleteVideo(int id);
        
        void UpdateVideo(Video video);
    }
}