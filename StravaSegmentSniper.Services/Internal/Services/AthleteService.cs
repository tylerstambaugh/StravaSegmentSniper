using AutoMapper;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IStravaAPIService _stravaAPIService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AthleteService(IStravaAPIService stravaAPIService, ITokenService tokenService, IMapper mapper)
        {
            _stravaAPIService = stravaAPIService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public DetailedAthleteModel GetDetailedAthlete(long stravaAthleteId)
        {           
            var token = _tokenService.GetTokenByStravaAthleteId(stravaAthleteId);
            if (token != null)
            {
                try
                {
                    DetailedAthleteModel athleteToReturn = new DetailedAthleteModel();
                    DetailedAthleteAPIModel athleteFromApi = _stravaAPIService.GetDetailedAthlete(token.AuthorizationToken).Result;

                    DetailedAthleteModel model = _mapper
                            .Map<DetailedAthleteAPIModel, DetailedAthleteModel>(athleteFromApi);
                    return athleteToReturn;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Exception Source{ex.Source}, \n +" +
                        $"Exception Message {ex.Message}");
                    return null;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(stravaAthleteId));
            }


        }

    }
}
