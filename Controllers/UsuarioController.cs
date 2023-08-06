// Controllers/UsuarioController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return Ok(new { Message = "Usuário registrado com sucesso!" });
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(Usuario usuario)
    {
        var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);

        if (user == null)
        {
            return Unauthorized(new { Message = "Credenciais inválidas!" });
        }

        return Ok(new { Message = "Login bem-sucedido!", UserId = user.Id });
    }
}