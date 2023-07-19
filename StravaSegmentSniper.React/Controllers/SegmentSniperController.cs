﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Segment;
using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;

namespace StravaSegmentSniper.React.Controllers
{

    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SegmentSniperController : ControllerBase
    {
        private readonly ISnipeSegmentActionHandler _stravaSegmentActionHandler;

        public SegmentSniperController(ISnipeSegmentActionHandler stravaSegmentActionHandler)
        {
            _stravaSegmentActionHandler = stravaSegmentActionHandler;
        }

        [HttpPost]
        [ActionName("SnipeSegments")]
        public IActionResult SnipeSegments(SegmentSniperContract contract)
        {
            //need to check API usage
            var returnList = _stravaSegmentActionHandler.HandleSnipingSegments(contract);
            if (returnList != null)
                return Ok(returnList);
            else
                return BadRequest("Unable to snipe segments with info provided.");;
        }
    }
        
}
