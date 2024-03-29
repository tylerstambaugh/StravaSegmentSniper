﻿//using StravaSegmentSniper.Data.Entities.User;
//using StravaSegmentSniper.Services.Internal.Models.Athlete;
//using StravaSegmentSniper.Services.Internal.Services;
//using StravaSegmentSniper.Services.StravaAPI.Athlete;
//using System.Diagnostics;

//namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
//{
//    public class ViewAthleteUI : IViewAthleteUI
//    {
//        private readonly IAthleteService _athleteService;
//        private readonly IGetAthleteActivityUI _getAthleteActivityUI;
//        private readonly IViewTrophyCaseUI _viewTrophyCaseUI;
//        private readonly IUserService _userService;
//        private readonly IStravaAPIAthlete _stravaAPIAthlete;

//        public ViewAthleteUI(IAthleteService athleteService, 
//                                IGetAthleteActivityUI getAthleteActivityUI, 
//                                IViewTrophyCaseUI viewTrophyCaseUI, 
//                                IUserService userService, 
//                                IStravaAPIAthlete stravaAPIAthlete)
//        {
//            _athleteService = athleteService;
//            _getAthleteActivityUI = getAthleteActivityUI;
//            _viewTrophyCaseUI = viewTrophyCaseUI;
//            _userService = userService;
//            _stravaAPIAthlete = stravaAPIAthlete;
//        }

//        public void ViewAthleteMenu()
//        {
//            bool runMenu = true;
//            Console.Clear();
//            List<ConsoleAppUser> users = _userService.GetAllConsoleAppUsers();
//            while (runMenu)
//            {
//                Console.Clear();
//                Console.WriteLine("Welcome to View Users \n");
//                if (users.Count == 0)
//                {
//                    Console.WriteLine("No athlete exist in the DB yet. Press any key to return. Yeet!");
//                    Console.ReadLine();
//                    runMenu = false;
//                }
//                else
//                {
//                    foreach (var user in users)
//                    {
//                        Console.WriteLine($"Athlete Id: {user.Id}  \n" +
//                                          $"First Name: {user.FirstName} \n" +
//                                          $"Last Name: {user.LastName} \n" +
//                                          $"Strava Id: {user.StravaAthleteId} \n" +
//                                          "-------------------------"
//                                          );
//                    }
//                    Console.WriteLine("Please enter an AthleteId and press enter (99 to exit):");
//                    var userInput = Console.ReadLine();
//                    int userInputInt = short.Parse(userInput);

//                    if (userInput == "99")
//                    {
//                        runMenu = false;
//                        break;
//                    }

//                    ConsoleAppUser selection = (ConsoleAppUser)users.Where(x => x.Id == userInputInt).First();
//                    if (selection != null)
//                    {
//                        ViewAthleteDetailsMenu(selection.Id);
//                    }
//                    else
//                    {
//                        InvalidSelection();
//                    }
//                }
//            }
//            return;
//        }
//        public void ViewAthleteDetailsMenu(int userId)
//        {
//            bool runMenu = true;
//            ConsoleAppUser user = _userService.GetConsoleAppUserByUserId(userId);
//            while (runMenu)
//            {
//                Console.Clear();
//                Console.WriteLine($"You are viewing the details of User: {user.FirstName} {user.LastName} \n" +
//                    $"1. View Athlete Details \n" +
//                    $"2. View Athlete Activity \n" +
//                    $"3. View Athlete Trophy Case \n" +
//                    $"99: Exit.");
//                Console.WriteLine("Please enter a selection and press enter (99 to exit):");
//                var userInput = Console.ReadLine();
//                int userInputInt = Int16.Parse(userInput);

//                switch (userInput)
//                {
//                    case "1":
//                        ViewAthleteDetails(userId);
//                        break;
//                    case "2":
//                        _getAthleteActivityUI.GetAthleteActivityMenu(user.Id);
//                        break;
//                    case "3":
//                        _viewTrophyCaseUI.ViewTrophyCase(user.Id);
//                        break;
//                    case "99":
//                        runMenu = false;
//                        break;
//                    default:
//                        InvalidSelection();
//                        break;
//                }
//            }
//        }

//        public void ViewAthleteDetails(int userId)
//        {
//            ConsoleAppUser user = _userService.GetConsoleAppUserByUserId(userId);
//            DetailedAthleteModel athlete = _stravaAPIAthlete.GetDetailedAthleteFromStrava(user.Id).Result;
//            if (user != null)
//            {
//                Console.WriteLine($"Athlete Details Retreived from Strava for {user.Id}, ({user.FirstName} {user.LastName})");
//                Console.WriteLine($"DetailedAthleteModel Username: {athlete.Username}");
//                Console.WriteLine($"DetailedAthleteModel Id: {athlete.Id}");
//                Console.WriteLine($"DetailedAthleteModel Sex: {athlete.Sex}");
//                Console.WriteLine($"DetailedAthleteModel LastName: {athlete.Lastname}");
//                Console.WriteLine($"DetailedAthleteModel FirstName: {athlete.Firstname}");
//                Console.WriteLine($"DetailedAthleteModel FriendCount: {athlete.FriendCount}");
//                Console.WriteLine($"DetailedAthleteModel Weight: {athlete.Weight}");
//                Console.WriteLine($"DetailedAthleteModel Bio: {athlete.Bio}");
//                Console.WriteLine($"DetailedAthleteModel: ...");
//            }

//            Console.WriteLine("Enter 333 to commit Athlete to Database, or anythin else to return");
//            string input = Console.ReadLine();
//            if (input == "333")
//            {
//               int response = _athleteService.SavedDetailedAtheleteToDb(athlete);

//                switch (response)
//                {
//                    case 1:
//                        Console.WriteLine($"DetailedAthlete Id {athlete.Id} was saved to the DB successfully");
//                        break;
//                    case -1:
//                        Console.WriteLine($"Some shit went wrong saving DetailedAthlete Id {athlete.Id} to the database. Please contact support");
//                        break;
//                    case -2:
//                        Console.WriteLine($"DetailedAthlete Id {athlete.Id} already exists and was not updated.");
//                        break;
//                    default:
//                        Console.WriteLine("This app needs A LOT of work");
//                        return;
//                }

//                Console.WriteLine("Press any key to return to the menu.");
//                Console.ReadLine();
//            }
//            else
//            {
//                return;
//            }
//        }


//        public void InvalidSelection()
//        {
//            Console.WriteLine("Please make a valid selection.");
//        }
//    }
//}
