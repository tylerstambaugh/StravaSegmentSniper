﻿//using StravaSegmentSniper.Data.Entities.User;
//using StravaSegmentSniper.Services.Internal.Services;

//namespace StravaSegmentSniper.ConsoleUI.UI.LocalDataUI
//{
//    public class ViewLocalAthleteActivityUI : IViewLocalAthleteActivityUI
//    {
//        private readonly IAthleteService _athleteService;
//        private readonly IUserService _userService;

//        public ViewLocalAthleteActivityUI(IAthleteService athleteService, IUserService userService)
//        {
//            _athleteService = athleteService;
//            _userService = userService;
//        }

//        public void ViewLocalAthleteActivity(int stravaAthleteId)
//        {
//            bool runMenu = true;
//            while (runMenu)
//            {
//                Console.Clear();

//                ConsoleAppUser user = _userService.GetConsoleAppUserByStravaId(stravaAthleteId);

//                Console.WriteLine($"You are viewing the activity for {user.FirstName} {user.LastName}, Strava ID= {user.Athlete.StravaAthleteId} \n" +
//                    $"Please type an option and press enter: \n" +
//                    $" Nothing Implemented Yet \n" +
//                    $"99. Exit");

//                var userInput = Console.ReadLine();
//                int userInputInt = short.Parse(userInput);

//                if (userInput == "99")
//                {
//                    runMenu = false;
//                    break;
//                }
//                switch (userInput)
//                {

//                    default:
//                        InvalidSelection();
//                        break;
//                }
//            }
//        }
//        public void InvalidSelection()
//        {
//            Console.WriteLine("Please make a valid selection. Press any key to try again");
//            Console.ReadLine();
//        }
//    }
//}
