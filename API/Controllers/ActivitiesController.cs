using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        /*Get all activities */
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        /*Pass in root parameter with "{}". Fetching an activity with activities/id */
        [HttpGet("{id}")] 
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            //find an activity with id which is being passed in.
            return await _context.Activities.FindAsync(id);
        }

    }
}
