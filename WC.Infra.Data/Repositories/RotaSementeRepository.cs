using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;

namespace WC.Infra.Data.Repositories
{
    public class RotaSementeRepository : ControllerBase, IRotaSementeRepository
    {
        private readonly AppDbContext _context;

        public RotaSementeRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RotaSemente
        public async Task<ActionResult<IEnumerable<RotaSementeEntity>>> GetRotaSementeEntity()
        {
            return await _context.RotaSementeEntity.ToListAsync();
        }

        // GET: api/RotaSemente/5
        public async Task<ActionResult<RotaSementeEntity>> GetRotaSementeEntity(Guid id)
        {
            var rotaSementeEntity = await _context.RotaSementeEntity.FindAsync(id);

            if (rotaSementeEntity == null)
            {
                return NotFound();
            }

            return rotaSementeEntity;
        }

        // PUT: api/RotaSemente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        public async Task<IActionResult> PutRotaSementeEntity(Guid id, RotaSementeEntity rotaSementeEntity)
        {
            if (id != rotaSementeEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(rotaSementeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaSementeEntityExists(id))
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

        // POST: api/RotaSemente
        public async Task<Guid> InserirRotaSementeAsync(RotaSementeEntity rotaSementeEntity)
        {

            _context.RotaSementeEntity.Add(rotaSementeEntity);
            await _context.SaveChangesAsync();

            return rotaSementeEntity.Id;
        }

        // DELETE: api/RotaSemente/5
        public async Task<IActionResult> DeleteRotaSementeEntity(Guid id)
        {
            var rotaSementeEntity = await _context.RotaSementeEntity.FindAsync(id);
            if (rotaSementeEntity == null)
            {
                return NotFound();
            }

            _context.RotaSementeEntity.Remove(rotaSementeEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotaSementeEntityExists(Guid id)
        {
            return _context.RotaSementeEntity.Any(e => e.Id == id);
        }
    }
}
