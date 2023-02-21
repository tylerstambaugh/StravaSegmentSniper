using Microsoft.AspNetCore.Identity;

namespace Authorization.Data.Models
{
    public class WebAppUser : IdentityUser
    {
        public long  StravaAthleteId { get; set; }
    }
}