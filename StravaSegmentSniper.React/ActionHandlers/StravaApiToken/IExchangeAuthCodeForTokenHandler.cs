namespace StravaSegmentSniper.React.ActionHandlers.StravaApiToken
{
    public interface IExchangeAuthCodeForTokenHandler
    {
        Task<ExchangeAuthCodeForTokenContract.Result> Execute(ExchangeAuthCodeForTokenContract contract);

    }

    public class ExchangeAuthCodeForTokenContract
    {
        public string AuthCode { get; set; }
        public string Scopes { get; set; }

        public class Result
        {
            public bool TokenWasAdded { get; set; }
        }


    }
}