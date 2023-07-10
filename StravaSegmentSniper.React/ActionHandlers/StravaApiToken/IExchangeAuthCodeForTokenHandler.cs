namespace StravaSegmentSniper.React.ActionHandlers.StravaApiToken
{
    public interface IExchangeAuthCodeForTokenHandler
    {
        Task Execute(ExchangeAuthCodeForTokenContract contract);

        public class Result
        {

        }

        
    }

    public class ExchangeAuthCodeForTokenContract
    {
        public string AuthCode { get; set; }

    }
}