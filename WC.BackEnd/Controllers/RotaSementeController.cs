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
    public class RotaSementeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IExecutarWebCrawlerAppService _executarWebCrawlerAppService;
        private readonly IInserirRotaSementeAppService _inserirRotaSementeAppService;

        public RotaSementeController(AppDbContext context, IMapper mapper, IInserirRotaSementeAppService inserirRotaSementeAppService, IExecutarWebCrawlerAppService executarWebCrawlerAppService)
        {
            _context = context;
            _mapper = mapper;
            _inserirRotaSementeAppService = inserirRotaSementeAppService;
            _executarWebCrawlerAppService = executarWebCrawlerAppService;
        }

        // GET: api/RotaSemente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RotaSementeEntity>>> GetRotaSementeEntity()
        {
            return await _context.RotaSementeEntity.ToListAsync();
        }

        // GET: api/RotaSemente/5
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> InserirRotaSementeAsync(RotaSementeModel rotaSementeModel)
        {
            var rotaSementeDto = _mapper.Map<RotaSementeDto>(rotaSementeModel);

            var rotaSementeId = await _inserirRotaSementeAppService.InserirRotaSementeAsync(rotaSementeDto);

            return CreatedAtAction("GetRotaSementeEntity", new { id = rotaSementeId }, rotaSementeModel);
        }

        // POST: api/RotaSemente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ExecutarWebCrawler")]
        public async Task<IActionResult> ExecutarWebCrawler(string nomeProduto, Enums.Ecommercer ecommerce)
        {
            RotaSementeModel rotaSementeModel = new RotaSementeModel();

            var rotaSementeId = await _executarWebCrawlerAppService.ExecutarWebCrawlerAsync(nomeProduto);

            return CreatedAtAction("GetRotaSementeEntity", new { id = rotaSementeId }, rotaSementeModel);
        }
        // DELETE: api/RotaSemente/5
        [HttpDelete("{id}")]
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
