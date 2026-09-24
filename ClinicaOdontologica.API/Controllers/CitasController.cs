using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class CitasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public CitasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Cita
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cita>>> GetCita()
    {
        return await _context.Citas.ToListAsync();
    }

    // GET: api/Cita/5
    [HttpGet("{idcita}")]
    public async Task<ActionResult<Cita>> GetCita(int idcita)
    {
        var cita = await _context.Citas.FindAsync(idcita);

        if (cita == null)
        {
            return NotFound();
        }

        return cita;
    }

    // PUT: api/Cita/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idcita}")]
    public async Task<IActionResult> PutCita(int? idcita, Cita cita)
    {
        if (idcita != cita.IdCita)
        {
            return BadRequest();
        }

        _context.Entry(cita).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CitaExists(idcita))
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

    // POST: api/Cita
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Cita>> PostCita(Cita cita)
    {
        _context.Citas.Add(cita);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCita", new { idcita = cita.IdCita }, cita);
    }

    // DELETE: api/Cita/5
    [HttpDelete("{idcita}")]
    public async Task<IActionResult> DeleteCita(int? idcita)
    {
        var cita = await _context.Citas.FindAsync(idcita);
        if (cita == null)
        {
            return NotFound();
        }

        _context.Citas.Remove(cita);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CitaExists(int? idcita)
    {
        return _context.Citas.Any(e => e.IdCita == idcita);
    }
}
