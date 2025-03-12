using System;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Activities.Queries;
using App.Activities.Queries;
using Application.Activities.Commands;

namespace API.Controllers
{
    // Derived from the BaseApiController, because it has routes
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            try
            {
                return await Mediator.Send(new GetActivityList.Query());
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await Mediator.Send(new GetActivityDetails.Query{ Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            return await Mediator.Send(new CreateActivity.Command{ Activity = activity });
        }

        [HttpPut]
        public async Task<ActionResult> EditActivity(Activity activity) 
        {
            await Mediator.Send(new EditActivity.Command{ Activity = activity });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id) 
        {
            await Mediator.Send(new DeleteActivity.Command{ Id = id });

            return Ok();
        }
    }
}
