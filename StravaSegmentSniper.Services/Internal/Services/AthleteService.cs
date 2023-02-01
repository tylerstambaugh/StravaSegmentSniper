using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly StravaSegmentSniperDBContext _context;


        public AthleteService(StravaSegmentSniperDBContext context)
        {
            _context = context;
        }

    }
}
