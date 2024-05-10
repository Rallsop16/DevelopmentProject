using Microsoft.AspNetCore.Http;
using DevelopmentProject.Data;
using DevelopmentProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentProject.Server.Controllers
{
    [Route("api/vocabData")]
    [ApiController]
    public class VocabController : ControllerBase
    {
        private readonly DataContext _context;

        public VocabController(DataContext context)
        {
            _context = context;
        }

        //Get all the users from the db
        [HttpGet]
        public async Task<ActionResult<List<Vocab>>> GetAllVocabAsync()
        {
            return await _context.Vocabs.ToListAsync();
        }

        //get a user by their id from the db
        [HttpGet("{Id}")]
        public async Task<ActionResult<Vocab>> GetVocabByIdAsync(int Id)
        {
            var result = await _context.Vocabs.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            return Ok(result);
        }

        //delete a user from the db
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteVocabAsync(int Id)
        {
            var result = await _context.Vocabs.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //update a user from the db
        [HttpPut("{Id}")]
        public async Task<ActionResult<Vocab>> UpdateVocabAsync(int Id, Vocab updatedVocab)
        {
            var dbResult = await _context.Vocabs.FindAsync(Id);
            if (dbResult == null)
                return NotFound("Vocab not found");


            dbResult.Original_word = updatedVocab.Original_word;
            dbResult.Translated_word = updatedVocab.Translated_word;
            dbResult.Original_language = updatedVocab.Original_language;
            dbResult.Translated_language = updatedVocab.Translated_language;
            dbResult.UserId = updatedVocab.UserId;


            await _context.SaveChangesAsync();

            return Ok(dbResult);
        }

        //creates a user in the db
        [HttpPost]
        public async Task<ActionResult<Vocab>> AddVocabAsync(Vocab newVocab)
        {
            _context.Add(newVocab);
            await _context.SaveChangesAsync();

            return Ok(newVocab);
        }
    }
}



