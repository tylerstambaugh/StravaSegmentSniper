using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.DataAccess;
using StravaSegmentSniper.Data.DataAccess.Athlete;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IStravaAPIService _stravaAPIService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly StravaSegmentSniperDbContext _context;
        private readonly IDataAccessEF _dataAccessEF;
        private readonly IAthleteData _athleteData;

        public AthleteService(IStravaAPIService stravaAPIService,
                                ITokenService tokenService, 
                                IMapper mapper,
                                StravaSegmentSniperDbContext context)
        {
            _stravaAPIService = stravaAPIService;
            _tokenService = tokenService;
            _mapper = mapper;
            _context = context;
        }

        public DetailedAthleteModel GetDetailedAthleteModel(int userId)
        {
            var token = _tokenService.GetTokenByUserId(userId);
            if (token != null)
            {
                try
                {
                    DetailedAthleteAPIModel athleteFromApi = _stravaAPIService.GetDetailedAthlete(token.AuthorizationToken).Result;

                    DetailedAthleteModel model = _mapper
                            .Map<DetailedAthleteAPIModel, DetailedAthleteModel>(athleteFromApi);

                    return model;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Source{ex.Source}, \n +" +
                        $"Exception Message {ex.Message}");
                    return null;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(userId));
            }
        }

        public List<DetailedAthlete> GetDetailedAthletes()
        {
            return _context.DetailedAthletes.ToList();
        }

        public int SavedDetailedAtheleteToDb(DetailedAthleteModel model)
        {
            DetailedAthlete athleteToSave = new DetailedAthlete
            {
                StravaAthleteId = model.Id,
                Username = model.Username,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Bio = model.Bio,
                Sex = model.Sex,
                Weight = model.Weight,
                Profile = model.Profile
            };

            var existingAthleteCount = _context.DetailedAthletes.Where(x => x.Id == detailedAthlete.Id).Count();
            if (existingAthleteCount > 0)
            {
                return -2;
            }
            else
            {
                _context.DetailedAthletes.Add(athleteToSave);

                //need to get the detailedAthlete ID and write it back to the user record

                if (_context.SaveChanges() == 1)
                    return 1;
                return -1;
            }
        }
    }
}
