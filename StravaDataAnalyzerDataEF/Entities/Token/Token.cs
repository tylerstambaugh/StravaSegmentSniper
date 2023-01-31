﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaSegmentSniper.Data.Entities.Token
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MetaAthlete")]
        public int StravaAthleteId { get; set; }
        public string? AuthorizationToken { get; set; }
        public string? RefreshToken { get; set; }
        public long ExpiresAt { get; set; }
        public long ExpiresIn { get; set; }
    }
}
