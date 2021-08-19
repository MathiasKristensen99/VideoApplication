using System;
using Microsoft.VisualBasic;

namespace EASV.VideoApplication
{
    internal class Menu
    {
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

        private void CreateVideo()
        {
            PrintNewLine();
            Console.WriteLine(StringConstants.VideoName);
            var videoName = Console.ReadLine();
            Console.WriteLine("Name of video: " + videoName);
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