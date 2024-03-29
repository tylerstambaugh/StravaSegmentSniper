﻿using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IAthleteService
    {
        int SavedDetailedAtheleteToDb(DetailedAthleteModel model);

        DetailedAthlete GetDetailedAthleteById(long stravaAthleteId);

        List<DetailedAthlete> GetDetailedAthletes();
    }
}