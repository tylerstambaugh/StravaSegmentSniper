using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.StravaAPI.Models.Token
{
    public class StravaApiExchangeTokenResponse
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public long expires_at { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public StravaApiExchangeTokenAthlete athlete { get; set; }
        
    }

    public class StravaApiExchangeTokenAthlete
    {
        public long id { get; set; }
        public string username { get; set; }
    }
}
