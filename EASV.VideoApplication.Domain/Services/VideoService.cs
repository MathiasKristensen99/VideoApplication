using System.Collections.Generic;
using EASV.VideoApplication.Domain.IRepositories;
using EASV.VideoApplication.Models;
using EASV.VideoApplication.Models.IServices;

namespace EASV.VideoApplication.Domain.Services
{
    public class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public List<Video> GetAllVideos()
        {
            return _videoRepository.GetAllVideos();
        }  

        public Video SearchVideoByName(string name)
        {
            return _videoRepository.SearchVideoByName(name);
        }

        public void DeleteVideo(int id)
        {
            _videoRepository.DeleteVideo(id);
        }

        public void UpdateVideo(Video video)
        {
            _videoRepository.UpdateVideo(video);
        }

        public void CreateNewVideo(Video video)
        {
            _videoRepository.CreateNewVideo(video);
        }
    }
}