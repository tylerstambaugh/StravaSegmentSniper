using Azure;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Data.Entities.User;
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
            List<ConsoleAppUser> users = _userService.GetAllUsers();
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the token menu \n");
                foreach (var user in users)
                {
                    Console.WriteLine($"User Id: {user.Id}, Strava AthleteId {user.StravaAthleteId}, {user.FirstName} {user.LastName}\n" +
                                      "-------------------------");
                }
                Console.WriteLine("Please enter a User ID and press enter (99 to exit):");
                var userInput = Console.ReadLine();
                long userInputInt = long.Parse(userInput);

                foreach (var user in users)
                {
                    if (userInputInt == user.Id)
                    {
                        ViewTokenForAthlete(user.Id);
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
        public void ViewTokenForAthlete(int userId)
        {
            bool runMenu = true;
            Console.Clear();
            Token token = _tokenService.GetTokenByUserId(userId);
            ConsoleAppUser user = _userService.GetUserByUserId(userId);

            Console.WriteLine($"You are viewing the token for {user.FirstName} {user.LastName}. \n" +
                $"Token: {token.AuthorizationToken} \n" +
                $"-----------" +
                "Please select an option: \n" +
                "1. Refresh Token \n" +
                "2. View Token Expiration Date \n" +
                "3. Exit");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    RefreshToken(userId);
                    break;
                case "2":
                    CheckTokenExpiration(token);
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
                $"The token is expired: {_tokenService.TokenIsExpired(token.UserId)} \n" +
                "Press any key to return.");
            Console.ReadLine();
        }

        //refresh the token for an athlete
        public void RefreshToken(int userId)
        {
            int response = _tokenService.RefreshToken(userId);
            if (response == 1)
                Console.WriteLine($"Token updated successfuly. Press enter to continue");
            else
            {
                Console.WriteLine($"The token was not updated and someone should figure out why. Press enter to continue");
            }
            Console.ReadLine();
        }

        private void InvalidSelection()
        {
            Console.WriteLine("Please make a valid selection.");
        }
    }
}
