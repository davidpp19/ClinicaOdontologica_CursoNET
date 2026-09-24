using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class RecetasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public RecetasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Receta
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Receta>>> GetReceta()
    {
        return await _context.Receta.ToListAsync();
    }

    // GET: api/Receta/5
    [HttpGet("{idreceta}")]
    public async Task<ActionResult<Receta>> GetReceta(int idreceta)
    {
        var receta = await _context.Receta.FindAsync(idreceta);

        if (receta == null)
        {
            return NotFound();
        }

        return receta;
    }

    // PUT: api/Receta/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idreceta}")]
    public async Task<IActionResult> PutReceta(int? idreceta, Receta receta)
    {
        if (idreceta != receta.IdReceta)
        {
            return BadRequest();
        }

        _context.Entry(receta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RecetaExists(idreceta))
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

    // POST: api/Receta
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Receta>> PostReceta(Receta receta)
    {
        _context.Receta.Add(receta);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReceta", new { idreceta = receta.IdReceta }, receta);
    }

    // DELETE: api/Receta/5
    [HttpDelete("{idreceta}")]
    public async Task<IActionResult> DeleteReceta(int? idreceta)
    {
        var receta = await _context.Receta.FindAsync(idreceta);
        if (receta == null)
        {
            return NotFound();
        }

        _context.Receta.Remove(receta);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RecetaExists(int? idreceta)
    {
        return _context.Receta.Any(e => e.IdReceta == idreceta);
    }
}
