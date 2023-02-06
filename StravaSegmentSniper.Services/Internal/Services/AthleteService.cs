﻿using AutoMapper;
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

        public AthleteService(IStravaAPIService stravaAPIService, ITokenService tokenService, IMapper mapper)
        {
            _stravaAPIService = stravaAPIService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public DetailedAthleteModel GetDetailedAthlete(int userId)
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
    }
}
