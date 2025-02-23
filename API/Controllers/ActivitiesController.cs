using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace API.Controllers
{
    // Derived from the BaseApiController, because it has routes
    public class ActivitiesController : BaseApiController
    {
        private readonly AppDbContext context;

        public ActivitiesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            try
            {
                return await context.Activities.ToListAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            var activity = await context.Activities.FindAsync(id);

            if (activity == null) return NotFound();

            return activity;
        }
    }
}
