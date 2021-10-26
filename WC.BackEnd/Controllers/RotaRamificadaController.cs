using AutoMapper;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.AppService.Interfaces;
using WC.Domain.DTO;
using WC.Infra.Data.Entities;
using WC.WebApi.Model;
using WC.Shared.Util;

namespace WC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaRamificadaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IExecutarWebScrapingAppService _executarWebScrapingAppService;

        public RotaRamificadaController(AppDbContext context, IMapper mapper, IExecutarWebScrapingAppService executarWebScrapingAppService)
        {
            _context = context;
            _mapper = mapper;
            _executarWebScrapingAppService = executarWebScrapingAppService;
        }

        // GET: api/RotaSemente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RotaRamificadaEntity>>> GetRotaRamificadaEntity()
        {
            return await _context.RotaRamificadaEntity.ToListAsync();
        }

        // GET: api/RotaSemente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RotaRamificadaEntity>> GetRotaRamificadaEntity(Guid id)
        {
            var RotaRamificadaEntity = await _context.RotaRamificadaEntity.FindAsync(id);

            if (RotaRamificadaEntity == null)
            {
                return NotFound();
            }

            return RotaRamificadaEntity;
        }

        // PUT: api/RotaSemente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRotaRamificadaEntity(Guid id, RotaRamificadaEntity RotaRamificadaEntity)
        {
            if (id != RotaRamificadaEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(RotaRamificadaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaRamificadaEntityExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<IActionResult> InserirRotaSementeAsync(RotaSementeModel rotaSementeModel)
        //{
        //    var rotaSementeDto = _mapper.Map<RotaSementeDto>(rotaSementeModel);

        //    var rotaSementeId = await _inserirRotaSementeAppService.InserirRotaSementeAsync(rotaSementeDto);

        //    return CreatedAtAction("GetRotaRamificadaEntity", new { id = rotaSementeId }, rotaSementeModel);
        //}

        // POST: api/RotaSemente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ExecutarWebCrawler")]
        public async Task<IActionResult> ExecutarWebScraping(string nomeProduto, Enums.Ecommercer ecommerce)
        {
            await _executarWebScrapingAppService.ExecutarWebScrapingAsync();

            return Ok();
        }
        // DELETE: api/RotaSemente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotaRamificadaEntity(Guid id)
        {
            var RotaRamificadaEntity = await _context.RotaRamificadaEntity.FindAsync(id);
            if (RotaRamificadaEntity == null)
            {
                return NotFound();
            }

            _context.RotaRamificadaEntity.Remove(RotaRamificadaEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotaRamificadaEntityExists(Guid id)
        {
            return _context.RotaRamificadaEntity.Any(e => e.Id == id);
        }
    }
}
