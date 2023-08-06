using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EstoqueController : ControllerBase
{
    private readonly AppDbContext _context;

    public EstoqueController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoque()
    {
        return await _context.Estoques.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Estoque>> GetEstoque(int id)
    {
        var estoque = await _context.Estoques.FindAsync(id);

        if (estoque == null)
        {
            return NotFound();
        }

        return estoque;
    }

    [HttpPost]
    public async Task<ActionResult<Estoque>> PostEstoque(Estoque estoque)
    {
        _context.Estoques.Add(estoque);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEstoque), new { id = estoque.IdEstoque }, estoque);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEstoque(int id, Estoque estoque)
    {
        if (id != estoque.IdEstoque)
        {
            return BadRequest();
        }

        _context.Entry(estoque).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstoqueExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstoque(int id)
    {
        var estoque = await _context.Estoques.FindAsync(id);
        if (estoque == null)
        {
            return NotFound();
        }

        _context.Estoques.Remove(estoque);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EstoqueExists(int id)
    {
        return _context.Estoques.Any(e => e.IdEstoque == id);
    }
}