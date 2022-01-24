using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Generics;
using WC.Infra.Data.Entities;
using WC.WebApi.Model;
using AutoMapper;
using WC.Domain.DTO;
using WC.AppService.Interfaces;

namespace WC.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IInserirProdutoAppService _inserirProdutoAppService;


        public ProdutoController(AppDbContext context, IMapper mapper, IInserirProdutoAppService inserirProdutoAppService)
        {
            _context = context;
            _mapper = mapper;
            _inserirProdutoAppService = inserirProdutoAppService;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoEntity>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoEntity>> GetProdutoEntity(Guid id)
        {
            var produtoEntity = await _context.Produtos.FindAsync(id);

            if (produtoEntity == null)
            {
                return NotFound();
            }

            return produtoEntity;
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoEntity(Guid id, ProdutoEntity produtoEntity)
        {
            if (id != produtoEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoEntityExists(id))
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

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> InserirProdutoAsync(ProdutoModel produtoModel)
        {
            var produtoDto = _mapper.Map<ProdutoDto>(produtoModel);

            var produtoId = await _inserirProdutoAppService.InserirProdutoAsync(produtoDto);

            return CreatedAtAction("GetProdutoEntity", new { id = produtoId }, produtoModel); 
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoEntity(Guid id)
        {
            var produtoEntity = await _context.Produtos.FindAsync(id);
            if (produtoEntity == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtoEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoEntityExists(Guid id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
