using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class ConsultoriosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public ConsultoriosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Consultorio
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consultorio>>> GetConsultorio()
    {
        return await _context.Consultorios.ToListAsync();
    }

    // GET: api/Consultorio/5
    [HttpGet("{idconsultorio}")]
    public async Task<ActionResult<Consultorio>> GetConsultorio(int idconsultorio)
    {
        var consultorio = await _context.Consultorios.FindAsync(idconsultorio);

        if (consultorio == null)
        {
            return NotFound();
        }

        return consultorio;
    }

    // PUT: api/Consultorio/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idconsultorio}")]
    public async Task<IActionResult> PutConsultorio(int? idconsultorio, Consultorio consultorio)
    {
        if (idconsultorio != consultorio.IdConsultorio)
        {
            return BadRequest();
        }

        _context.Entry(consultorio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsultorioExists(idconsultorio))
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

    // POST: api/Consultorio
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Consultorio>> PostConsultorio(Consultorio consultorio)
    {
        _context.Consultorios.Add(consultorio);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsultorio", new { idconsultorio = consultorio.IdConsultorio }, consultorio);
    }

    // DELETE: api/Consultorio/5
    [HttpDelete("{idconsultorio}")]
    public async Task<IActionResult> DeleteConsultorio(int? idconsultorio)
    {
        var consultorio = await _context.Consultorios.FindAsync(idconsultorio);
        if (consultorio == null)
        {
            return NotFound();
        }

        _context.Consultorios.Remove(consultorio);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsultorioExists(int? idconsultorio)
    {
        return _context.Consultorios.Any(e => e.IdConsultorio == idconsultorio);
    }
}
