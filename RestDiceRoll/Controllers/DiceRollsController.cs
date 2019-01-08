using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestDiceRoll.Models;

namespace RestDiceRoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceRollsController : ControllerBase
    {
        private readonly DiceRollContext _context;

        public DiceRollsController(DiceRollContext context)
        {
            _context = context;
        }

        // GET: api/DiceRolls
        [HttpGet]
        public IEnumerable<DiceRoll> GetDiceRolls()
        {
            return _context.DiceRolls;
        }

        // GET: api/DiceRolls/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiceRoll([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diceRoll = await _context.DiceRolls.FindAsync(id);

            if (diceRoll == null)
            {
                return NotFound();
            }

            return Ok(diceRoll);
        }

        // PUT: api/DiceRolls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiceRoll([FromRoute] int id, [FromBody] DiceRoll diceRoll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diceRoll.Id)
            {
                return BadRequest();
            }

            _context.Entry(diceRoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiceRollExists(id))
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

        // POST: api/DiceRolls
        [HttpPost]
        public async Task<IActionResult> PostDiceRoll([FromBody] DiceRoll diceRoll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DiceRolls.Add(diceRoll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiceRoll", new { id = diceRoll.Id }, diceRoll);
        }

        // DELETE: api/DiceRolls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiceRoll([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diceRoll = await _context.DiceRolls.FindAsync(id);
            if (diceRoll == null)
            {
                return NotFound();
            }

            _context.DiceRolls.Remove(diceRoll);
            await _context.SaveChangesAsync();

            return Ok(diceRoll);
        }

        private bool DiceRollExists(int id)
        {
            return _context.DiceRolls.Any(e => e.Id == id);
        }
    }
}