using StravaDataAnalyzerDataEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.ConsoleUI.UI.LocalDataUI
{
    public class ViewLocalDataUI : IViewLocalDataUI
    {
        private readonly IViewLocalAthleteInfoUI _viewLocalAthleteInfoUI;

        public ViewLocalDataUI(IViewLocalAthleteInfoUI viewLocalAthleteInfoUI)
        {
            _viewLocalAthleteInfoUI = viewLocalAthleteInfoUI;
        }

        public void ViewLocalDataMenu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Strava Data Analyzer Local Data Query SubSystem");
                Console.WriteLine($"Please input an option and press enter \n" +
                    $"1. View Athlete Info \n" +
                    $"2. Check Token Status \n" +
                    $"3. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        _viewLocalAthleteInfoUI.ViewLocalAthleteMenu(); 
                        break;
                    case "3":
                        runMenu = false;
                        break;
                    default:
                        InvalidSelection();
                        break;
                }
            }

        }

        public void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection. Press any key to continue");
            Console.ReadLine();
        }
    }
}
