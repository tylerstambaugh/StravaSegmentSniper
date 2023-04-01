using StravaSegmentSniper.Data.Entities.User;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI.LocalDataUI
{
    public class ViewLocalAthleteInfoUI : IViewLocalAthleteInfoUI
    {
        private readonly IAthleteService _athleteService;
        private readonly IViewLocalAthleteActivityUI _viewLocalAthleteActivityUI;
        private readonly IUserService _userService;

        public ViewLocalAthleteInfoUI(IAthleteService athleteService, IViewLocalAthleteActivityUI viewLocalAthleteActivityUI, IUserService userService)
        {
            _athleteService = athleteService;
            _viewLocalAthleteActivityUI = viewLocalAthleteActivityUI;
            _userService = userService;
        }
        public void ViewLocalAthleteMenu()
        {
            bool runMenu = true;
            Console.Clear();
            List<ConsoleAppUser> users = _userService.GetAllConsoleAppUsers();
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to View Athlete \n");
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

                var selection = users.Where(x => x.Id == userInputInt).First();
                if (selection != null)
                {
                    ViewAthleteDetailsMenu(selection.StravaAthleteId);
                }
                else
                {
                    InvalidSelection();
                }
            }
            return;
        }
        public void ViewAthleteDetailsMenu(long stravaAthleteId)
        {
            bool runMenu = true;
            ConsoleAppUser user = _userService.GetConsoleAppUserByStravaId(stravaAthleteId);
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine($"You are viewing the details of {user.FirstName} {user.LastName} \n" +
                    $"1. View Athlete Activity \n" +
                    $"2. View Athlete Trophy Case \n" +
                    $"99: Exit.");
                Console.WriteLine("Please enter a selection and press enter (99 to exit):");
                var userInput = Console.ReadLine();
                int userInputInt = Int16.Parse(userInput);

                switch (userInput)
                {
                    case "1":
                        //_viewAthleteActivityUI.ViewAthleteActivity(athlete.Id);
                        break;
                    case "2":
                        //_viewTrophyCaseUI.ViewTrophyCase(athlete.Id);
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
