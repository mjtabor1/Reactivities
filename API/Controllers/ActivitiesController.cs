using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Application.Activities;
using System.Threading.Tasks;
using Domain;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        /*Get all activities */
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        /*Pass in root parameter with "{}". Fetching an activity with activities/id */
        [HttpGet("{id}")] 
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            //find an activity with id which is being passed in.
            return await Mediator.Send(new Details.Query { Id = id });
        }

        //IActionResult gives us access to HTTP response types
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            //use object initializer syntax {Activity=activity}
            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}
