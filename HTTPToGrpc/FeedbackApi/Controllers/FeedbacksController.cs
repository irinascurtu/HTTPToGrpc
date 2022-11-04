using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackApi.Data.Entities;
using FeedbackApi.Data.Repositories;
using FeedbackApi.Infrastructure;
using FeedbackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<Feedback>> Get()
        //{
        //    return feedbackService.GetAll();
        //}

        [HttpGet]
        public IEnumerable<Feedback> Get()
        {
            return feedbackService.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Feedback> GetById(int id)
        {
            return feedbackService.GetById(id);
        }


        //[HttpGet]
        //[CommaQueryString]
        //[Route("multiple")]
        //public async Task<IEnumerable<Feedback>> Get([FromQuery] List<int> talks)
        //{
        //    return await feedbackService.GetForIds(talks);
        //}



    }
}