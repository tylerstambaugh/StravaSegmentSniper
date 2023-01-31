using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI.LocalDataUI
{
    public class ViewLocalAthleteInfoUI : IViewLocalAthleteInfoUI
    {
        private readonly IAthleteService _athleteService;
        private readonly IViewLocalAthleteActivityUI _viewLocalAthleteActivityUI;

        public ViewLocalAthleteInfoUI(IAthleteService athleteService, IViewLocalAthleteActivityUI viewLocalAthleteActivityUI)
        {
            _athleteService = athleteService;
            _viewLocalAthleteActivityUI = viewLocalAthleteActivityUI;
        }
        public void ViewLocalAthleteMenu()
        {
            bool runMenu = true;
            Console.Clear();
            List<User> athletes = _athleteService.GetAllUsers();
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to View Athlete \n");
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

                var selection = athletes.Where(x => x.Id == userInputInt).ToList();
                if (selection != null)
                {
                    ViewAthleteDetailsMenu(userInputInt);
                }
                else
                {
                    InvalidSelection();
                }
            }
            return;
        }
        public void ViewAthleteDetailsMenu(int stravaAthleteId)
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
