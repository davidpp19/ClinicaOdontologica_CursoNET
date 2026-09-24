using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class OdontologosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public OdontologosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Odontologo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Odontologo>>> GetOdontologo()
    {
        return await _context.Odontologo.ToListAsync();
    }

    // GET: api/Odontologo/5
    [HttpGet("{idodontologo}")]
    public async Task<ActionResult<Odontologo>> GetOdontologo(int idodontologo)
    {
        var odontologo = await _context.Odontologo.FindAsync(idodontologo);

        if (odontologo == null)
        {
            return NotFound();
        }

        return odontologo;
    }

    // PUT: api/Odontologo/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idodontologo}")]
    public async Task<IActionResult> PutOdontologo(int? idodontologo, Odontologo odontologo)
    {
        if (idodontologo != odontologo.IdOdontologo)
        {
            return BadRequest();
        }

        _context.Entry(odontologo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OdontologoExists(idodontologo))
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

    // POST: api/Odontologo
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Odontologo>> PostOdontologo(Odontologo odontologo)
    {
        _context.Odontologo.Add(odontologo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOdontologo", new { idodontologo = odontologo.IdOdontologo }, odontologo);
    }

    // DELETE: api/Odontologo/5
    [HttpDelete("{idodontologo}")]
    public async Task<IActionResult> DeleteOdontologo(int? idodontologo)
    {
        var odontologo = await _context.Odontologo.FindAsync(idodontologo);
        if (odontologo == null)
        {
            return NotFound();
        }

        _context.Odontologo.Remove(odontologo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OdontologoExists(int? idodontologo)
    {
        return _context.Odontologo.Any(e => e.IdOdontologo == idodontologo);
    }
}
