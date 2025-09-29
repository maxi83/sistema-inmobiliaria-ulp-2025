using System.Security.Claims;
using sistema_inmobiliaria_ulp_2025.Models;
using sistema_inmobiliaria_ulp_2025.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace sistema_inmobiliaria_ulp_2025.Models;


public class CuentaController : Controller
{
    private readonly IUserRepository _userRepository;

    public CuentaController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Registrar([FromBody] User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await _userRepository.AddAsync(user);
        await _userRepository.SaveAsync();

        return Ok(new { message = "Completado con éxito." });
    }

    [HttpGet]
    public IActionResult IniciarSesion()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IniciarSesion([FromForm] User user)
    {
        var usuarioEnDB = await _userRepository.GetByUsernameAsync(user.Username);

        if (usuarioEnDB == null || !BCrypt.Net.BCrypt.Verify(user.Password, usuarioEnDB.Password))
        {
            ModelState.AddModelError("", "Usuario o Contraseña incorrectos.");
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuarioEnDB.Username),
            new Claim(ClaimTypes.Role, usuarioEnDB.Rol),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult CerrarSesion()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> _CerrarSesion()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("IniciarSesion");
    }
}