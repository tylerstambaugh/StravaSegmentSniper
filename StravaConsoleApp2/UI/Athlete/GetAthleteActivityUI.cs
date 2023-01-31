using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniperServices.Library.Internal.Models.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Segment;
using StravaSegmentSniperServices.Library.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public class GetAthleteActivityUI : IGetAthleteActivityUI
    {
        private readonly IAthleteService _athleteService;
        private readonly IAthleteActivityService _athleteActivityService;

        public GetAthleteActivityUI(IAthleteService athleteService, IAthleteActivityService athleteActivityService)
        {
            _athleteService = athleteService;
            _athleteActivityService = athleteActivityService;
        }

        public void GetAthleteActivityMenu(long stravaAthleteId)
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();

                User athlete = _athleteService.GetUserByStravaId(stravaAthleteId);

                Console.WriteLine($"You are viewing the activity for {athlete.FirstName} {athlete.LastName}, Strava ID= {athlete.StravaAthleteId} \n" +
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
                        GetSummaryActivityForATimeRange(stravaAthleteId);
                        break;
                    case "2":
                        GetDetailedActivityById(stravaAthleteId);
                        break;
                    case "3":
                        GetAllSegmentEffortsByActivityId(stravaAthleteId);
                        break;
                    case "4":
                        GetSegmentEffortById(stravaAthleteId);
                        break;
                    default:
                        InvalidSelection();
                        break;
                }
            }
        }

        public void GetSummaryActivityForATimeRange(long stravaAthleteId)
        {
            Console.Clear();
            User athlete = _athleteService.GetUserByStravaId(stravaAthleteId);

            Console.WriteLine("Enter the start date in epoch time:");
            string startDateInput = Console.ReadLine();
            int startDate = Int32.Parse(startDateInput);

            Console.WriteLine("Enter the end date in epoch time:");
            string endDateInput = Console.ReadLine();
            int endDate = Int32.Parse(endDateInput);

            List<SummaryActivityModel> listOfActivities = _athleteActivityService
                .GetSummaryActivityForATimeRange(stravaAthleteId, startDate, endDate).ToList();

            Console.WriteLine($"You are viewing the activity for {athlete.FirstName} {athlete.LastName}, Strava ID= {athlete.StravaAthleteId}");

            foreach (SummaryActivityModel activities in listOfActivities)
            {
                Console.WriteLine($"Activity ID: {activities.Id}, Activity name: {activities.Name}");
            }

            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }

        public void GetDetailedActivityById(long stravaAthleteId)
        {
            Console.Clear();
            bool run = true;
            User athlete = _athleteService.GetUserByStravaId(stravaAthleteId);
            while (run)
            {
                Console.Clear();
                Console.WriteLine($"Enter the activity ID for {athlete.FirstName} {athlete.LastName} (99 to exit)");
                var input = Console.ReadLine();
                if (input == "99")
                {
                    run = false;
                    break;
                }

                long activityId = Int64.Parse(input);
                DetailedActivityModel activity = _athleteActivityService.GetDetailedActivityByActivityId(stravaAthleteId, activityId);

                Console.WriteLine($"You are viewing the activity {activityId} for Strava ID= {athlete.StravaAthleteId}");
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
                    Console.WriteLine(_athleteActivityService.SaveDetailedActivityToDB(activity));
                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadLine();
                }
            }
        }

        public void GetAllSegmentEffortsByActivityId(long stravaAthleteId)
        {

        }
        private void GetSegmentEffortById(long stravaAthleteId)
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



