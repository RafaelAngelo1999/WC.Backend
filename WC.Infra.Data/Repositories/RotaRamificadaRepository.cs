using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;
using WC.Shared.Exceptions;

namespace WC.Infra.Data.Repositories
{
    public class RotaRamificadaRepository : ControllerBase, IRotaRamificadaRepository
    {
        private readonly AppDbContext _context;

        public RotaRamificadaRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RotaSemente
        public async Task<ActionResult<IEnumerable<RotaSementeEntity>>> GetRotaSementeEntity()
        {
            return await _context.RotaSementeEntity.ToListAsync();
        }

        // GET: api/RotaSemente/5
        public async Task<RotaRamificadaEntity> ObterRotaRamificadaAsync(Guid id)
        {
            var rotaRamificadaEntity = await _context.RotaRamificadaEntity.FindAsync(id);

            if (rotaRamificadaEntity == null)
            {
                //return NotFound();
            }

            return rotaRamificadaEntity;
        }

        // GET: api/RotaSemente/5
        public async Task<IEnumerable<RotaRamificadaEntity>> ObterRotaRamificadaNotScrapingAsync()
        {
            var rotaRamificadaEntity =  _context.RotaRamificadaEntity.Where(c => c.WasScraping == false)
                    .OrderBy(x => x.Url)
                    .Take(100);

            if (rotaRamificadaEntity == null)
            {
                throw new AplicacaoException("Não foi encontrado registro");
            }

            return rotaRamificadaEntity;
        }

        // PUT: api/RotaSemente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        public async Task AtualizarRotaRamificadaAsync(Guid id, RotaRamificadaEntity rotaRamificadaEntity)
        {
            if (id != rotaRamificadaEntity.Id)
            {
                //return BadRequest();
            }

            _context.Entry(rotaRamificadaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaRamificadaEntityExists(id))
                {
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
        }

        // POST: api/RotaSemente
        //public async Task<Guid> InserirRotaSementeAsync(RotaSementeEntity rotaSementeEntity)
        //{

        //    _context.RotaSementeEntity.Add(rotaSementeEntity);
        //    await _context.SaveChangesAsync();

        //    return rotaSementeEntity.Id;
        //}

        // DELETE: api/RotaSemente/5
        //public async Task<IActionResult> DeleteRotaSementeEntity(Guid id)
        //{
        //    var rotaSementeEntity = await _context.RotaSementeEntity.FindAsync(id);
        //    if (rotaSementeEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.RotaSementeEntity.Remove(rotaSementeEntity);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool RotaRamificadaEntityExists(Guid id)
        {
            return _context.RotaRamificadaEntity.Any(e => e.Id == id);
        }
    }
}
