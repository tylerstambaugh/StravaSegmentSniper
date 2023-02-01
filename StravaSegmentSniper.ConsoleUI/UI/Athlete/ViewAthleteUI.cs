using StravaSegmentSniper.Data.Entities.Athlete;
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
                    Console.WriteLine("No athlete exist in the DB yet. Yeet!");
                }
                else
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"Athlete Id: {user.Id}  \n" +
                                          $"First Name: {user.FirstName} \n" +
                                          $"Last Name: {user.LastName} \n" +
                                          $"Strava Id: {user.Athlete.StravaAthleteId} \n" +
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
                        ViewAthleteDetailsMenu(selection.Athlete.StravaAthleteId);
                    }
                    else
                    {
                        InvalidSelection();
                    }
                }
            }
            return;
        }
        public void ViewAthleteDetailsMenu(long stravaAthleteId)
        {
            bool runMenu = true;
            User user = _userService.GetUserByStravaId(stravaAthleteId);
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
                        throw new NotImplementedException();
                        break;            
                    case "2":
                        _getAthleteActivityUI.GetAthleteActivityMenu(user.Athlete.StravaAthleteId);
                        break;
                    case "3":
                        _viewTrophyCaseUI.ViewTrophyCase(user.Athlete.StravaAthleteId);
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
        public void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection.");
        }
    }
}
