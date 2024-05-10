using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevelopmentProject.Data;
using DevelopmentProject.Shared.Entities;

namespace DevelopmentProject.Controllers
{
    [Route("api/statisticsData")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly DataContext _context;

        public StatisticsController(DataContext context)
        {
            _context = context;
        }

        //Get all the users from the db
        [HttpGet]
        public async Task<ActionResult<List<Statistics>>> GetAllStatisticsAsync()
        {
            return await _context.Statistics.ToListAsync();
        }

        //get a user by their id from the db
        [HttpGet("{Id}")]
        public async Task<ActionResult<Statistics>> GetStatisticsByIdAsync(int Id)
        {
            var result = await _context.Statistics.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            return Ok(result);
        }

        //delete a user from the db
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStatisticsAsync(int Id)
        {
            var result = await _context.Statistics.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //update a user from the db
        [HttpPut("{Id}")]
        public async Task<ActionResult<Statistics>> UpdateStatisticsAsync(int Id, Statistics updatedStatistics)
        {
            var dbResult = await _context.Statistics.FindAsync(Id);
            if (dbResult == null)
                return NotFound("Statistics not found");

            dbResult.Experience = updatedStatistics.Experience;
            dbResult.Time = updatedStatistics.Time;

            await _context.SaveChangesAsync();

            return Ok(dbResult);
        }

        //creates a user in the db
        [HttpPost]
        public async Task<ActionResult<Statistics>> AddStatisticsAsync(Statistics newStatistics)
        {
            _context.Add(newStatistics);
            await _context.SaveChangesAsync();

            return Ok(newStatistics);
        }
    }
}



