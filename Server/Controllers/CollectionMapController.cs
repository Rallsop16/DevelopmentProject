using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevelopmentProject.Data;
using DevelopmentProject.Shared.Entities;

namespace DevelopmentProject.Controllers
{
	[Route("api/collectionMaps")]
	[ApiController]
	public class CollectionMapController : ControllerBase
	{
		private readonly DataContext _context;

		public CollectionMapController(DataContext context)
		{
			_context = context;
		}

		//Get all the users from the db
		[HttpGet]
		public async Task<ActionResult<List<CollectionMap>>> GetAllCollectionsAsync()
		{
			return await _context.CollectionMaps.ToListAsync();
		}

		//get a user by their id from the db
		[HttpGet("{Id}")]
		public async Task<ActionResult<CollectionMap>> GetCollectionByIdAsync(int Id)
		{
			var result = await _context.CollectionMaps.FindAsync(Id);
			if (result == null)
				return NotFound(result);

			return Ok(result);
		}

		//delete a user from the db
		[HttpDelete("{Id}")]
		public async Task<IActionResult> DeleteCollectionAsync(int Id)
		{
			var result = await _context.CollectionMaps.FindAsync(Id);
			if (result == null)
				return NotFound(result);

			_context.Remove(result);
			await _context.SaveChangesAsync();

			return Ok();
		}

		//update a user from the db
		[HttpPut("{Id}")]
		public async Task<ActionResult<CollectionMap>> UpdateCollectionAsync(int Id, CollectionMap updatedCollectionMap)
		{
			var dbResult = await _context.CollectionMaps.FindAsync(Id);
			if (dbResult == null)
				return NotFound("Collection Map not found");

			dbResult.VocabId = updatedCollectionMap.VocabId;
			dbResult.CollectionVocabId = updatedCollectionMap.CollectionVocabId;

			await _context.SaveChangesAsync();

			return Ok(dbResult);
		}

		//creates a user in the db
		[HttpPost]
		public async Task<ActionResult<CollectionMap>> AddCollectionAsync(CollectionMap newCollectionMap)
		{
			_context.Add(newCollectionMap);
			await _context.SaveChangesAsync();

			return Ok(newCollectionMap);
		}
	}
}



