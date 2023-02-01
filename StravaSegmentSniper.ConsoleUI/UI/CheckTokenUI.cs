using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.ConsoleUI.UI
{
    public class CheckTokenUI : ICheckTokenUI
    {
        private readonly ITokenService _tokenService;
        private readonly IAthleteService _athleteService;
        private readonly IUserService _userService;

        public CheckTokenUI(ITokenService tokenService, IAthleteService athleteService, IUserService userService)
        {
            _tokenService = tokenService;
            _athleteService = athleteService;
            _userService = userService;
        }
        public void ViewTokenMenu()
        {
            bool runMenu = true;
            Console.Clear();
            List<User> users = _userService.GetAllUsers();
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the token menu \n");
                foreach (var athlete in users)
                {
                    Console.WriteLine($"User Id: {athlete.Id}, Strava AthleteId {athlete.Athlete.StravaAthleteId}, {athlete.FirstName} {athlete.LastName}\n" +
                                      "-------------------------");
                }
                Console.WriteLine("Please enter a User ID and press enter (99 to exit):");
                var userInput = Console.ReadLine();
                long userInputInt = long.Parse(userInput);

                foreach (var athlete in users)
                {
                    if (userInputInt == athlete.Id)
                    {
                        ViewTokenForAthlete(athlete.Athlete.StravaAthleteId);
                    }
                    else
                    {
                        InvalidSelection();
                    }
                }
                if (userInput == "99")
                {
                    runMenu = false;
                }
            }
            return;
        }

        //display the token for an athlete
        public void ViewTokenForAthlete(long stravaAthleteId)
        {
            bool runMenu = true;
            Console.Clear();
            Token athleteToken = _tokenService.GetTokenByStravaAthleteId(stravaAthleteId);
            User user = _userService.GetUserByStravaId(stravaAthleteId);

            Console.WriteLine($"You are viewing the token for {user.FirstName} {user.LastName}. \n" +
                $"Token: {athleteToken.AuthorizationToken} \n" +
                $"-----------" +
                "Please select an option: \n" +
                "1. Refresh Token \n" +
                "2. View Token Expiration Date \n" +
                "3. Exit");


            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    RefreshToken(athleteToken.RefreshToken, athleteToken.User.Athlete.StravaAthleteId);
                    break;
                case "2":
                    CheckTokenExpiration(athleteToken);
                    break;
                default:
                    InvalidSelection();
                    break;
            }
        }

        // check when the token expires
        public void CheckTokenExpiration(Token token)
        {
            Console.Clear();
            Console.WriteLine($"Checking Token {token.AuthorizationToken} Expiration... \n" +
                $"Current time is: {DateTimeOffset.UtcNow} \n" +
                $"Token expires at: {DateTimeOffset.FromUnixTimeSeconds(token.ExpiresAt)} \n" +
                $"The token is expired: {_tokenService.TokenIsExpired(token.User.Athlete.StravaAthleteId)} \n" +
                "Press any key to return.");
            Console.ReadLine();
        }

        //refresh the token for an athlete
        public void RefreshToken(string refreshToken, long stravaAthleteId)
        {
            Token refreshedToken = _tokenService.RefreshToken(refreshToken, stravaAthleteId);
        }

        private void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection.");
        }
    }
}
