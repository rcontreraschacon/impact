using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.News;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly IMediator _mediator;


        public NewsController(IMediator mediator, ILogger<NewsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> List([FromQuery] string feed)
        {
            return await _mediator.Send(new List.Query { Url = feed });
        }
    }
}
