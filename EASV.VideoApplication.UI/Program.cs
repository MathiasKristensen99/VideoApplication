using System;
using EASV.VideoApplication.DB;
using EASV.VideoApplication.Domain.IRepositories;
using EASV.VideoApplication.Domain.Services;
using EASV.VideoApplication.Models;
using EASV.VideoApplication.Models.IServices;

namespace EASV.VideoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IVideoRepository repo = new VideoRepository();
            IVideoService service = new VideoService(repo);
            
            Menu menu = new Menu(service);
            menu.Start();
        }
    }
}