using StravaSegmentSniper.React.ActionHandlers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.React.ActionHandlers
{
    public interface IStravaActivityActionHandler
    {
        ActivityListModel HandleGetActivityById(HandleGetActivityByIdContract contract);
    }
}