using System;
using System.Collections.Generic;
using System.IO;
using EASV.VideoApplication.Domain.IRepositories;
using EASV.VideoApplication.Models;
using EASV.VideoApplication.Models.IServices;
using Microsoft.VisualBasic;

namespace EASV.VideoApplication
{
    internal class Menu
    {
        private IVideoService _videoService;

        public Menu(IVideoService service)
        {
            _videoService = service;
        }

        public void Start()
        {
            ShowWelcomeGreeting();
            StartLoop();
        }
        private void ShowWelcomeGreeting()
        {
            Console.WriteLine(StringConstants.WelcomeGreeting);
        }

        private void ShowMainMenu()
        {
            Console.WriteLine(StringConstants.SelectMenuItem);
            Console.WriteLine(StringConstants.SelectCreateVideo);
            Console.WriteLine(StringConstants.SelectShowAllVideos);
            Console.WriteLine(StringConstants.SelectSearchVideo);
            Console.WriteLine(StringConstants.SelectDeleteVideo);
            Console.WriteLine(StringConstants.SelectUpdateVideo);
            Console.WriteLine(StringConstants.SelectExit);

        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == -1)
                {
                    PleaseTryAgain();
                }

                if (choice == 1)
                {
                    CreateVideo();
                }

                if (choice == 2)
                {
                    ShowAllVideos();
                }
                
                if (choice == 3)
                {
                    SearchVideo();
                }

                if (choice == 4)
                {
                    DeleteVideo();
                }

                if (choice == 5)
                {
                    UpdateVideo();
                }
            }
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }

            return -1;
        }

        private int GetVideoSearchSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }
        
        private void PrintNewLine()
        {
            Console.WriteLine("\n");
        }

        private void ShowAllVideos()
        {
            List<Video> videos = _videoService.GetAllVideos();
            foreach (Video video in videos)
            {
                Console.WriteLine("Id: " + video.Id + " Name: " + video.Name + " Release date: " + video.Release + " Storyline: " + video.Storyline);
            }
        }

        private void DeleteVideo()
        {
            ShowAllVideos();
            PrintNewLine();
            Console.WriteLine("Select a video to delete, by typing the id and hit enter");
            
            var idString = Console.ReadLine();
            int idToDelete = 0;
            int id;

            if (int.TryParse(idString, out id))
            {
                idToDelete = id;
            }
            
            _videoService.DeleteVideo(idToDelete);
            PrintNewLine();
            Console.WriteLine("The video has been deleted");
        }

        private void UpdateVideo()
        {
            ShowAllVideos();
            PrintNewLine();
            
            Console.WriteLine("Select a video to update, by typing the id and hit enter");
            
            var idString = Console.ReadLine();
            int idToUpdate = 0;
            int id;

            if (int.TryParse(idString, out id))
            {
                idToUpdate = id;
            }

            List<Video> videos = _videoService.GetAllVideos();

            foreach (Video video in videos)
            {
                if (video.Id.Equals(idToUpdate))
                {
                    Console.WriteLine("You have selected: Name: " + video.Name + " Release: " + video.Release + " Storyline: " + video.Storyline);
                }
            }
        }
        
        private void CreateVideo()
        {
            Video video = new Video();
            PrintNewLine();
            
            Console.WriteLine(StringConstants.Id);
            var idString = Console.ReadLine();
            int id;

            if (int.TryParse(idString, out id))
            {
                video.Id = id;
            }
            
            Console.WriteLine(StringConstants.VideoName);
            var videoName = Console.ReadLine();

            video.Name = videoName;
            
            Console.WriteLine(StringConstants.Release);
            string release = Console.ReadLine();
            var parsedRelease = DateTime.Parse(release);

            video.Release = parsedRelease;
            Console.WriteLine(parsedRelease);

            Console.WriteLine(StringConstants.Storyline);
            var storyline = Console.ReadLine();

            video.Storyline = storyline;
            
            _videoService.CreateNewVideo(video);
        }

        private void SearchVideo()
        {
            Console.WriteLine(StringConstants.VideoSearch);
            int choice;
            while ((choice = GetVideoSearchSelection()) != 0)
            {
                if (choice == 1)
                {
                    
                }

                if (choice == 2)
                {
                    SearchMovieByName();
                }
            }
        }

        private void SearchMovieByName()
        {
            Console.WriteLine(StringConstants.SearchName);
            var movieName = Console.ReadLine();
            
            _videoService.SearchVideoByName(movieName);
        }

        private void PleaseTryAgain()
        {
            Console.WriteLine("Invalid number, please try again");
        }
    }
}