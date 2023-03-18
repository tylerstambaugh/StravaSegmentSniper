using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniperReact.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Data.DataAccess.Athlete
{
    public class AthleteData : IAthleteData
    {
        private readonly StravaSegmentSniperDbContext _stravaSegmentSniperDbContext;

        public AthleteData(StravaSegmentSniperDbContext stravaSegmentSniperDbContext)
        {
            _stravaSegmentSniperDbContext = stravaSegmentSniperDbContext;
        }

        public List<DetailedAthlete> GetDetailedAthletes()
        {                       
            return _stravaSegmentSniperDbContext.DetailedAthletes.ToList();
        }

        public int SaveDetailedAthlete(DetailedAthlete detailedAthlete)
        {
            var existingActivityCount = _stravaSegmentSniperDbContext.DetailedAthletes.Where(x => x.Id == detailedAthlete.Id).Count();
            if (existingActivityCount > 0)
            {
                return -2;
            }
            else
            {
                _stravaSegmentSniperDbContext.DetailedAthletes.Add(detailedAthlete);

                if (_stravaSegmentSniperDbContext.SaveChanges() == 1)
                    return 1;
                return -1;
            }
        }
    }
}
