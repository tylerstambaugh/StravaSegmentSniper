using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniperServices.Library.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public class ViewAthleteUI : IViewAthleteUI
    {
        private readonly IAthleteService _athleteService;
        private readonly IGetAthleteActivityUI _getAthleteActivityUI;
        private readonly IViewTrophyCaseUI _viewTrophyCaseUI;

        public ViewAthleteUI(IAthleteService athleteService, IGetAthleteActivityUI getAthleteActivityUI, IViewTrophyCaseUI viewTrophyCaseUI)
        {
            _athleteService = athleteService;
            _getAthleteActivityUI = getAthleteActivityUI;
            _viewTrophyCaseUI = viewTrophyCaseUI;
        }

        public void ViewAthleteMenu()
        {
            bool runMenu = true;
            Console.Clear();
            List<User> athletes = _athleteService.GetAllUsers();
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to View Athlete \n");
                if (athletes.Count == 0)
                {
                    Console.WriteLine("No athlete exist in the DB yet. Yeet!");
                }
                else
                {

                    foreach (var athlete in athletes)
                    {
                        Console.WriteLine($"Athlete Id: {athlete.Id}  \n" +
                                          $"First Name: {athlete.FirstName} \n" +
                                          $"Last Name: {athlete.LastName} \n" +
                                          $"Strava Id: {athlete.StravaAthleteId} \n" +
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

                    User selection = (User)athletes.Where(x => x.Id == userInputInt).First();
                    if (selection != null)
                    {
                        ViewAthleteDetailsMenu(selection.StravaAthleteId);
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
            User athlete = _athleteService.GetUserByStravaId(stravaAthleteId);
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine($"You are viewing the details of {athlete.FirstName} {athlete.LastName} \n" +
                    $"1. View Athlete Activity \n" +
                    $"2. View Athlete Trophy Case \n" +
                    $"99: Exit.");
                Console.WriteLine("Please enter a selection and press enter (99 to exit):");
                var userInput = Console.ReadLine();
                int userInputInt = Int16.Parse(userInput);

                switch (userInput)
                {
                    case "1":
                        _getAthleteActivityUI.GetAthleteActivityMenu(athlete.StravaAthleteId);
                        break;
                    case "2":
                        _viewTrophyCaseUI.ViewTrophyCase(athlete.StravaAthleteId);
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
