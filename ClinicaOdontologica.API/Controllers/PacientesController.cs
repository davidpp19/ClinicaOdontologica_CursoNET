using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public PacientesController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Paciente
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()
    {
        return await _context.Paciente.ToListAsync();
    }

    // GET: api/Paciente/5
    [HttpGet("{idpaciente}")]
    public async Task<ActionResult<Paciente>> GetPaciente(int idpaciente)
    {
        var paciente = await _context.Paciente.FindAsync(idpaciente);

        if (paciente == null)
        {
            return NotFound();
        }

        return paciente;
    }

    // PUT: api/Paciente/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idpaciente}")]
    public async Task<IActionResult> PutPaciente(int? idpaciente, Paciente paciente)
    {
        if (idpaciente != paciente.IdPaciente)
        {
            return BadRequest();
        }

        _context.Entry(paciente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PacienteExists(idpaciente))
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

    // POST: api/Paciente
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
    {
        _context.Paciente.Add(paciente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPaciente", new { idpaciente = paciente.IdPaciente }, paciente);
    }

    // DELETE: api/Paciente/5
    [HttpDelete("{idpaciente}")]
    public async Task<IActionResult> DeletePaciente(int? idpaciente)
    {
        var paciente = await _context.Paciente.FindAsync(idpaciente);
        if (paciente == null)
        {
            return NotFound();
        }

        _context.Paciente.Remove(paciente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PacienteExists(int? idpaciente)
    {
        return _context.Paciente.Any(e => e.IdPaciente == idpaciente);
    }
}
