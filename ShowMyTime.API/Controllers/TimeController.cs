using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShowMyTime.Application.Interfaces;
using ShowMyTime.Application.Services;
using ShowMyTime.Domain.Models;

namespace ShowMyTime.API.Controllers
{
    // http://localhost:5000/api/time
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTime()
        {
            var timeModels = await _timeService.GetLocalTimeByGivenLocation();
           
            return Ok(timeModels);
        }
    }
}