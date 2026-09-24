using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class FacturasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public FacturasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Factura
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Factura>>> GetFactura()
    {
        return await _context.Facturas.ToListAsync();
    }

    // GET: api/Factura/5
    [HttpGet("{idfactura}")]
    public async Task<ActionResult<Factura>> GetFactura(int idfactura)
    {
        var factura = await _context.Facturas.FindAsync(idfactura);

        if (factura == null)
        {
            return NotFound();
        }

        return factura;
    }

    // PUT: api/Factura/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idfactura}")]
    public async Task<IActionResult> PutFactura(int? idfactura, Factura factura)
    {
        if (idfactura != factura.IdFactura)
        {
            return BadRequest();
        }

        _context.Entry(factura).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FacturaExists(idfactura))
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

    // POST: api/Factura
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Factura>> PostFactura(Factura factura)
    {
        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFactura", new { idfactura = factura.IdFactura }, factura);
    }

    // DELETE: api/Factura/5
    [HttpDelete("{idfactura}")]
    public async Task<IActionResult> DeleteFactura(int? idfactura)
    {
        var factura = await _context.Facturas.FindAsync(idfactura);
        if (factura == null)
        {
            return NotFound();
        }

        _context.Facturas.Remove(factura);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FacturaExists(int? idfactura)
    {
        return _context.Facturas.Any(e => e.IdFactura == idfactura);
    }
}
