﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StravaSegmentController : ControllerBase
    {
        public StravaSegmentController()
        {

        }

        // GET api/<Segment>/5
        [HttpGet("{id}")]
        public DetailedSegmentModel Get(int id)
        {
            return new DetailedSegmentModel();
        }
    }
}
