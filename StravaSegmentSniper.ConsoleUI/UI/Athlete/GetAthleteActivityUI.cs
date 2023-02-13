using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;

namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public class GetAthleteActivityUI : IGetAthleteActivityUI
    {
        private readonly IAthleteService _athleteService;
        private readonly IAthleteActivityService _athleteActivityService;
        private readonly IUserService _userService;

        public GetAthleteActivityUI(IAthleteService athleteService, IAthleteActivityService athleteActivityService, IUserService userService)
        {
            _athleteService = athleteService;
            _athleteActivityService = athleteActivityService;
            _userService = userService;
        }

        public void GetAthleteActivityMenu(int userId)
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();

                User user = _userService.GetUserByUserId(userId);

                Console.WriteLine($"You are viewing the activity for {user.FirstName} {user.LastName}, Strava ID = {user.StravaAthleteId} \n" +
                    $"Please type an option and press enter: \n" +
                    $"1. Get all athlete activity for a date range \n" +
                    $"2. Get athlete activity by Activity ID \n" +
                    $"3. Get all segment efforts by Activity ID \n" +
                    $"4. Get segment effort details by effort Id \n" +
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
                        GetSummaryActivityForATimeRange(user.Id);
                        break;
                    case "2":
                        GetDetailedActivityById(user.Id);
                        break;
                    case "3":
                        GetAllSegmentEffortsByActivityId(user.Id);
                        break;
                    case "4":
                        GetSegmentEffortById(user.Id);
                        break;
                    default:
                        InvalidSelection();
                        break;
                }
            }
        }

        public void GetSummaryActivityForATimeRange(int userId)
        {
            Console.Clear();
            User user = _userService.GetUserByUserId(userId);

            Console.WriteLine("Enter the start date in epoch time:");
            string startDateInput = Console.ReadLine();
            int startDate = Int32.Parse(startDateInput);

            Console.WriteLine("Enter the end date in epoch time:");
            string endDateInput = Console.ReadLine();
            int endDate = Int32.Parse(endDateInput);

            List<SummaryActivityModel> listOfActivities = _athleteActivityService
                .GetSummaryActivityForATimeRange(userId, startDate, endDate).ToList();

            Console.WriteLine($"You are viewing the activity for {user.FirstName} {user.LastName}, Strava ID= {user.Athlete.StravaAthleteId}");

            foreach (SummaryActivityModel activities in listOfActivities)
            {
                Console.WriteLine($"Activity ID: {activities.Id}, Activity name: {activities.Name}");
            }

            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }

        public void GetDetailedActivityById(int userId)
        {
            Console.Clear();
            bool run = true;
            User user = _userService.GetUserByUserId(userId);
            while (run)
            {
                Console.Clear();
                Console.WriteLine($"Enter the activity ID for {user.FirstName} {user.LastName} (99 to exit)");
                var input = Console.ReadLine();
                if (input == "99")
                {
                    run = false;
                    break;
                }

                long activityId = Int64.Parse(input);
                DetailedActivityModel activity = _athleteActivityService.GetDetailedActivityByActivityId(userId, activityId);

                Console.WriteLine($"You are viewing the activity {activityId} for Strava ID= {user.StravaAthleteId}");
                Console.WriteLine($"Name: {activity.Name} Id:{activityId}");
                if (activity.SegmentEfforts != null)
                {
                    foreach (DetailedSegmentEffortModel segmentEffort in activity.SegmentEfforts)
                    {
                        Console.WriteLine($"It contains segment: {segmentEffort.Name}, SegmentEffortID: {segmentEffort.Id}," +
                            $" Segment Id: {segmentEffort.Segment.Id}");
                    }
                }

                Console.WriteLine("Press 69 to commit to database or enter to look up another");
                string endInput = Console.ReadLine();
                if (endInput == "69")
                {
                    int response = _athleteActivityService.SaveDetailedActivityToDB(activity, (int)user.DetailedAthleteId);
                    switch (response)
                    {
                        case 1:
                            Console.WriteLine($"DetailedActivity Id {activity.Id} was saved to the DB successfully");
                            break;
                        case -1:
                            Console.WriteLine($"Some shit went wrong saving DeatiledActivity Id {activity.Id} to the database. Please contact support");
                            break;
                        case -2:
                            Console.WriteLine($"DetailedActivity Id {activity.Id} already exists and was not updated.");
                            break;
                        default:
                            Console.WriteLine("This app needs A LOT of work");
                            return;
                    }

                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadLine();
                }
            }
        }

        public void GetAllSegmentEffortsByActivityId(int userId)
        {

        }
        private void GetSegmentEffortById(int userId)
        {
            throw new NotImplementedException();
        }
        public void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection. Press any key to try again");
            Console.ReadLine();
        }
    }
}



