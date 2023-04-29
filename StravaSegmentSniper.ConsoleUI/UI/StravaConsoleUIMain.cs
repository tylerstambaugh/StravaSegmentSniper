//using StravaSegmentSniper.ConsoleUI.UI.Athlete;
//using StravaSegmentSniper.ConsoleUI.UI.LocalDataUI;

//namespace StravaSegmentSniper.ConsoleUI.UI
//{
//    public class StravaConsoleUIMain : IStravaConsoleUIMain
//    {
//        private readonly IViewAthleteUI _viewAthleteUI;
//        private readonly ICheckTokenUI _checkTokenUI;
//        private readonly IViewLocalDataUI _viewLocalDataUI;

//        public StravaConsoleUIMain(IViewAthleteUI viewAthleteUI, ICheckTokenUI checkTokenUI,
//            IViewLocalDataUI viewLocalDataUI)
//        {
//            _viewAthleteUI = viewAthleteUI;
//            _checkTokenUI = checkTokenUI;
//            _viewLocalDataUI = viewLocalDataUI;
//        }
//        public void PrintMenu()
//        {
//            Console.WriteLine("Welcome to the Strava Data Analyzer Console Application \n" +
//                  "Please select an option \n" +
//                "\n" +
//                "1. View Athlete Info From Strava API \n" +
//                "2. View Local Data \n" +
//                "3. Check Token \n" +
//                "99. Exit");
//        }
//        public void Run()
//        {
//            bool runApplication = true;
//            while (runApplication)
//            {
//                Console.Clear();
//                PrintMenu();
//                var userInput = Console.ReadLine();
//                switch (userInput)
//                {
//                    case "1":
//                        _viewAthleteUI.ViewAthleteMenu();
//                        break;
//                    case "2":
//                        _viewLocalDataUI.ViewLocalDataMenu();
//                        break;
//                    case "3":
//                        _checkTokenUI.ViewTokenMenu(); 
//                        break;
//                    case "99":
//                        if (ConfirmExit())
//                        {
//                            runApplication = false;
//                        }
//                        break;
//                    default:
//                        InvalidSelection();
//                        break;
//                }
//            }
//        }

//        private void InvalidSelection()
//        {
//            Console.WriteLine("Please make a valid selection. Press any key to try again");
//            Console.ReadLine();
//        }

//        private bool ConfirmExit()
//        {
//            Console.WriteLine("Are you sure you want to exit y/n?");
//            var userInput = Console.ReadLine().ToLower();

//            if (userInput == "y")
//                return true;
//            else return false;
//        }

//    }
//}
