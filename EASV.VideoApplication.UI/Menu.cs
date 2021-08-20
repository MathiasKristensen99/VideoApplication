using System;
using System.Collections.Generic;
using System.IO;
using EASV.VideoApplication.Models;
using Microsoft.VisualBasic;

namespace EASV.VideoApplication
{
    internal class Menu
    {
        private VideoManager videoManager = new VideoManager();
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
            throw new NotImplementedException();
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
            List<Video> videos = videoManager.GetAllVideos();
            foreach (Video video in videos)
            {
                Console.WriteLine(video.Id + " " + video.Name + " " + video.Release + " " + video.Storyline);
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

            Console.WriteLine(StringConstants.Storyline);
            var storyline = Console.ReadLine();

            video.Storyline = storyline;
            
            videoManager.CreateNewVideo(video);
            
            //Console.WriteLine("Name of video: " + videoName);
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
            }
        }

        private void PleaseTryAgain()
        {
            Console.WriteLine("Invalid number, please try again");
        }
        
    }
}