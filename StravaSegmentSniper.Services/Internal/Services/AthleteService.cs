using AutoMapper;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.StravaAPI;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly StravaSegmentSniperDbContext _context;

        public AthleteService(StravaSegmentSniperDbContext context)
        {
            
            _context = context;
        }


        public List<DetailedAthlete> GetDetailedAthletes()
        {
            return _context.DetailedAthletes.ToList();
        }

        public DetailedAthlete GetDetailedAthleteById(long stravaAthleteId)
        {
           var detailedAthleteToReturn = _context.DetailedAthletes.Where(x => x.Id == stravaAthleteId).First();
            if (detailedAthleteToReturn != null)
                return detailedAthleteToReturn;
            throw new ArgumentNullException("athleteId", "The provided Id was not found in the database");
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

            var existingAthleteCount = _context.DetailedAthletes.Where(x => x.Id == athleteToSave.Id).Count();
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
