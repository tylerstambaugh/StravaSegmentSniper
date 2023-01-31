using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI.LocalDataUI
{
    public class ViewLocalAthleteActivityUI : IViewLocalAthleteActivityUI
    {
        private readonly IAthleteService _athleteService;
        private readonly StravaSegmentSniperDBContext _context = new StravaSegmentSniperDBContext();

        public ViewLocalAthleteActivityUI(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        public void ViewLocalAthleteActivity(int stravaAthleteId)
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();

                User athlete = _athleteService.GetUserByStravaId(stravaAthleteId);

                Console.WriteLine($"You are viewing the activity for {athlete.FirstName} {athlete.LastName}, Strava ID= {athlete.StravaAthleteId} \n" +
                    $"Please type an option and press enter: \n" +
                    $" Nothing Implemented Yet \n" +
                    $"99. Exit");

                var userInput = Console.ReadLine();
                int userInputInt = short.Parse(userInput);

                if (userInput == "99")
                {
                    runMenu = false;
                    break;
                }
                switch (userInput)
                {

                    default:
                        InvalidSelection();
                        break;
                }
            }
        }

        public void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection. Press any key to try again");
            Console.ReadLine();
        }
    }
}
