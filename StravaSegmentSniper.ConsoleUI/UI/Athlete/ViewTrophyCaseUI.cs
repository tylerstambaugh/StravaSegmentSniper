using StravaSegmentSniper.Data.Entities.User;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public class ViewTrophyCaseUI : IViewTrophyCaseUI
    {
        private readonly IAthleteActivityService _athleteActivityService;
        private readonly IUserService _userService;

        public ViewTrophyCaseUI(IAthleteActivityService athleteActivityService, 
                                IUserService userService)
        {
            _athleteActivityService = athleteActivityService;
            _userService = userService;
        }

        public void ViewTrophyCase(int userId)
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();

                ConsoleAppUser user = _userService.GetConsoleAppUserByStravaId(userId);

                Console.WriteLine($"You are viewing the trophy case for {user.FirstName} {user.LastName}, Strava ID= {user.StravaAthleteId} \n" +
                    $"Please type an option and press enter: \n" +
                    $"1. View all detailed segments \n" +
                    $"2. View all crowns on segments \n" +
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
                    case "1":
                        ViewAllDetailedSegments(userId);
                        break;
                    case "2":
                        throw new NotImplementedException();
                    default:
                        InvalidSelection();
                        break;
                }
            }
        }

        public void ViewAllDetailedSegments(int userId)
        {
            Console.Clear();
            ConsoleAppUser user = _userService.GetConsoleAppUserByUserId(userId);

            List<DetailedSegmentModel> segments = _athleteActivityService.GetAllDetailedSegments(userId);


            Console.WriteLine($"You are viewing the top ten segment results for {user.FirstName} {user.LastName}, Strava ID = {user.StravaAthleteId}");

            foreach (DetailedSegmentModel segment in segments)
            {
                if (segment != null)
                {
                    Console.WriteLine($"Segment Name: {segment.Name}, KOM Time: {segment.Xoms.Overall}, Your Time: {segment.AthleteSegmentStats.PrElapsedTime}");
                }
            }

            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }

        public void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection. Press any key to continue");
            Console.ReadLine();
        }
    }
}
