using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;
using BCrypt.Net;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public UsuariosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Usuario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
    {
        return await _context.Usuarios.ToListAsync();
    }

    // GET: api/Usuario/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }

    // PUT: api/Usuario/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int? id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }

        var usuarioExistente = await _context.Usuarios.FindAsync(id);
        if (usuarioExistente == null)
        {
            return NotFound();
        }
        usuarioExistente.nombre = usuario.nombre;
        usuarioExistente.apellido = usuario.apellido;
        usuarioExistente.correo = usuario.correo;
        usuarioExistente.nombreUsuario = usuario.nombreUsuario;

        if(!string.IsNullOrEmpty(usuario.contrasenia))
        {
            usuarioExistente.contrasenia = BCrypt.Net.BCrypt.HashPassword(usuario.contrasenia);
        }
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // POST: api/Usuario
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        var existe = await _context.Usuarios.AnyAsync(u => u.correo.ToLower() == usuario.correo.ToLower());
        if(existe)
        {
            return Conflict("Ya existe un usuario con el mismo correo.");
        }

        usuario.contrasenia = BCrypt.Net.BCrypt.HashPassword(usuario.contrasenia);
        _context.Usuarios.Add(usuario);
        return CreatedAtAction(nameof(GetUsuario), new {id = usuario.Id}, usuario);

    }

    // DELETE: api/Usuario/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int? id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioExists(int? id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
}
