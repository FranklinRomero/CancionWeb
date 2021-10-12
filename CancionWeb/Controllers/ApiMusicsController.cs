using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CancionWeb.Data;
using CancionWeb.Models;

namespace CancionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMusicsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApiMusicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiMusics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusics()
        {
            return await _context.Musics.ToListAsync();
        }

        // GET: api/ApiMusics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusic(string id)
        {
            var music = await _context.Musics.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }

            return music;
        }

        // PUT: api/ApiMusics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusic(string id, Music music)
        {
            if (id != music.Cancion)
            {
                return BadRequest();
            }

            _context.Entry(music).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiMusics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            _context.Musics.Add(music);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MusicExists(music.Cancion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMusic", new { id = music.Cancion }, music);
        }

        // DELETE: api/ApiMusics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(string id)
        {
            var music = await _context.Musics.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicExists(string id)
        {
            return _context.Musics.Any(e => e.Cancion == id);
        }
    }
}
