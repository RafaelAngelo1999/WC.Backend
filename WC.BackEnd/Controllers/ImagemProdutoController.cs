using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Infra.Data.Entities;


namespace WC.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagemProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ImagemProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ImagemProdutoRepository
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImagemProdutoEntity>>> GetImagens()
        {
            return await _context.ImagensProdutos.ToListAsync();
        }

        // GET: api/ImagemProdutoRepository/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImagemProdutoEntity>> GetImagemProdutoEntity(Guid id)
        {
            var imagemProdutoEntity = await _context.ImagensProdutos.FindAsync(id);

            if (imagemProdutoEntity == null)
            {
                return NotFound();
            }

            return imagemProdutoEntity;
        }

        // PUT: api/ImagemProdutoRepository/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagemProdutoEntity(Guid id, ImagemProdutoEntity imagemProdutoEntity)
        {
            if (id != imagemProdutoEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(imagemProdutoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagemProdutoEntityExists(id))
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

        // POST: api/ImagemProdutoRepository
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImagemProdutoEntity>> PostImagemProdutoEntity(ImagemProdutoEntity imagemProdutoEntity)
        {
            _context.ImagensProdutos.Add(imagemProdutoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagemProdutoEntity", new { id = imagemProdutoEntity.Id }, imagemProdutoEntity);
        }

        // DELETE: api/ImagemProdutoRepository/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagemProdutoEntity(Guid id)
        {
            var imagemProdutoEntity = await _context.ImagensProdutos.FindAsync(id);
            if (imagemProdutoEntity == null)
            {
                return NotFound();
            }

            _context.ImagensProdutos.Remove(imagemProdutoEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagemProdutoEntityExists(Guid id)
        {
            return _context.ImagensProdutos.Any(e => e.Id == id);
        }
    }
}
