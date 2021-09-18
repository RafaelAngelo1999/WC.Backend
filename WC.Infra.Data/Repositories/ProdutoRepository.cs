using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Generics;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;

namespace WC.Infra.Data.Repositories
{
    public class ProdutoRepository : ControllerBase, IProdutoRepository
    {
        private readonly AppDbContext _context;


        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ProdutoEntity>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ActionResult<ProdutoEntity>> GetProdutoEntity(Guid id)
        {
            var produtoEntity = await _context.Produtos.FindAsync(id);

            if (produtoEntity == null)
            {
                return NotFound();
            }

            return produtoEntity;
        }
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
        public async Task<Guid> InserirCotacaoAsync(ProdutoEntity produtoEntity)
        {
            produtoEntity.Create_At = DateTime.Now;
            produtoEntity.Update_At = DateTime.Now;
            _context.Produtos.Add(produtoEntity);
            await _context.SaveChangesAsync();

            return produtoEntity.Id;
        }

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
