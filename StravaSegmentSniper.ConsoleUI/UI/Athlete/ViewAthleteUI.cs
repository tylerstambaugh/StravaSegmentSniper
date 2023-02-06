using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public class ViewAthleteUI : IViewAthleteUI
    {
        private readonly IAthleteService _athleteService;
        private readonly IGetAthleteActivityUI _getAthleteActivityUI;
        private readonly IViewTrophyCaseUI _viewTrophyCaseUI;
        private readonly IUserService _userService;

        public ViewAthleteUI(IAthleteService athleteService, IGetAthleteActivityUI getAthleteActivityUI, IViewTrophyCaseUI viewTrophyCaseUI, IUserService userService)
        {
            _athleteService = athleteService;
            _getAthleteActivityUI = getAthleteActivityUI;
            _viewTrophyCaseUI = viewTrophyCaseUI;
            _userService = userService;
        }

        public void ViewAthleteMenu()
        {
            bool runMenu = true;
            Console.Clear();
            List<User> users = _userService.GetAllUsers();
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to View Users \n");
                if (users.Count == 0)
                {
                    Console.WriteLine("No athlete exist in the DB yet. Press any key to return. Yeet!");
                    Console.ReadLine();
                    runMenu = false;
                }
                else
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"Athlete Id: {user.Id}  \n" +
                                          $"First Name: {user.FirstName} \n" +
                                          $"Last Name: {user.LastName} \n" +
                                          $"Strava Id: {user.StravaAthleteId} \n" +
                                          "-------------------------"
                                          );
                    }
                    Console.WriteLine("Please enter an AthleteId and press enter (99 to exit):");
                    var userInput = Console.ReadLine();
                    int userInputInt = short.Parse(userInput);

                    if (userInput == "99")
                    {
                        runMenu = false;
                        break;
                    }

                    User selection = (User)users.Where(x => x.Id == userInputInt).First();
                    if (selection != null)
                    {
                        ViewAthleteDetailsMenu(selection.Id);
                    }
                    else
                    {
                        InvalidSelection();
                    }
                }
            }
            return;
        }
        public void ViewAthleteDetailsMenu(int userId)
        {
            bool runMenu = true;
            User user = _userService.GetUserByUserId(userId);
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine($"You are viewing the details of User: {user.FirstName} {user.LastName} \n" +
                    $"1. View Athlete Details \n" +
                    $"2. View Athlete Activity \n" +
                    $"3. View Athlete Trophy Case \n" +
                    $"99: Exit.");
                Console.WriteLine("Please enter a selection and press enter (99 to exit):");
                var userInput = Console.ReadLine();
                int userInputInt = Int16.Parse(userInput);

                switch (userInput)
                {
                    case "1":
                        ViewAthleteDetails(userId);
                        break;            
                    case "2":
                        _getAthleteActivityUI.GetAthleteActivityMenu(user.Id);
                        break;
                    case "3":
                        _viewTrophyCaseUI.ViewTrophyCase(user.Id);
                        break;
                    case "99":
                        runMenu = false;
                        break;
                    default:
                        InvalidSelection();
                        break;
                }
            }
        }

        public void ViewAthleteDetails(int userId)
        {
            User user = _userService.GetUserByUserId(userId);
            DetailedAthleteModel athlete = _athleteService.GetDetailedAthlete(user.Id);
            if(user != null)
            {
                Console.WriteLine($"Athlete Details Retreived from Strava for {user.Id}, ({user.FirstName} {user.LastName})");
                Console.WriteLine($"DetailedAthleteModel: {athlete.Username}");
                Console.WriteLine($"DetailedAthleteModel: {athlete.Id}");
                Console.WriteLine($"DetailedAthleteModel: {athlete.Sex}");
                Console.WriteLine($"DetailedAthleteModel: {athlete.Lastname}");
                Console.WriteLine($"DetailedAthleteModel: {athlete.Firstname}");
                Console.WriteLine($"DetailedAthleteModel: {athlete.FriendCount}");
                Console.WriteLine($"DetailedAthleteModel: {athlete.Weight}");
                Console.WriteLine($"DetailedAthleteModel: {athlete.Bio}");
                Console.WriteLine($"DetailedAthleteModel: ...");
            }

            Console.WriteLine("Enter 123 to commit Athlete to Database, or anythingelse to return");
            string input = Console.ReadLine();
            if(input == "123")
            {
                //commit the athlete to the DB
            }
            else
            {
                return;
            }

        }


        public void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection.");
        }
    }
}
