using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevelopmentProject.Data;
using DevelopmentProject.Shared.Entities;

namespace DevelopmentProject.Controllers
{
    [Route("api/collectionData")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly DataContext _context;

        public CollectionsController(DataContext context)
        {
            _context = context;
        }

        //Get all the users from the db
        [HttpGet]
        public async Task<ActionResult<List<CollectionVocab>>> GetAllCollectionsAsync()
        {
            return await _context.CollectionVocabs.ToListAsync();
        }

        //get a user by their id from the db
        [HttpGet("{Id}")]
        public async Task<ActionResult<CollectionVocab>> GetCollectionByIdAsync(int Id)
        {
            var result = await _context.CollectionVocabs.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            return Ok(result);
        }

        //delete a user from the db
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCollectionAsync(int Id)
        {
            var result = await _context.CollectionVocabs.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //update a user from the db
        [HttpPut("{Id}")]
        public async Task<ActionResult<CollectionVocab>> UpdateCollectionAsync(int Id, CollectionVocab updatedCollection)
        {
            var dbResult = await _context.CollectionVocabs.FindAsync(Id);
            if (dbResult == null)
                return NotFound("Collection not found");

            dbResult.CollectionVocabName = updatedCollection.CollectionVocabName;
            dbResult.UserId = updatedCollection.UserId;

            await _context.SaveChangesAsync();

            return Ok(dbResult);
        }

        //creates a user in the db
        [HttpPost]
        public async Task<ActionResult<CollectionVocab>> AddCollectionAsync(CollectionVocab newCollection)
        {
            _context.Add(newCollection);
            await _context.SaveChangesAsync();

            return Ok(newCollection);
        }
    }
}


