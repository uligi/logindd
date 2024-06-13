using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loginregistermenu.Data;
using loginregistermenu.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace loginregistermenu.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarUsuario()
        {
            var generos = await _context.Generos.ToListAsync();
            var model = new UsuarioRegistroViewModel
            {
                Generos = generos,
                Direcciones = new List<Direccion> { new Direccion() },
                Telefonos = new List<Telefono> { new Telefono() },
                Correos = new List<Correo> { new Correo() }
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(UsuarioRegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Usuario.Rol = "cliente"; // Asignar rol predeterminado
                _context.Personas.Add(model.Persona);
                await _context.SaveChangesAsync();

                model.Usuario.PersonaID = model.Persona.PersonaID;
                _context.Usuarios.Add(model.Usuario);
                await _context.SaveChangesAsync();

                foreach (var direccion in model.Direcciones)
                {
                    direccion.UsuarioID = model.Usuario.Id;
                    _context.Direcciones.Add(direccion);
                }

                foreach (var telefono in model.Telefonos)
                {
                    telefono.PersonaID = model.Persona.PersonaID;
                    _context.Telefonos.Add(telefono);
                }

                foreach (var correo in model.Correos)
                {
                    correo.PersonaID = model.Persona.PersonaID;
                    _context.Correos.Add(correo);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            model.Generos = await _context.Generos.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u =>
                        (u.Correo == model.Correo || u.Nombre == model.Correo) &&
                        u.Contrasena == model.Contrasena);

                if (usuario != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Correo),
                        new Claim(ClaimTypes.Role, usuario.Rol)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Correo, nombre o contraseña incorrectos.");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Persona)
                .Include(u => u.Direcciones)
                .Include(u => u.Telefonos)
                .FirstOrDefaultAsync(u => u.Correo == User.Identity.Name);

            if (usuario == null)
            {
                return NotFound();
            }

            var generos = await _context.Generos.ToListAsync();

            var model = new UsuarioPerfilViewModel
            {
                Usuario = usuario,
                Persona = usuario.Persona,
                Direcciones = usuario.Direcciones.ToList(),
                Telefonos = usuario.Telefonos.ToList(),
                Generos = generos
            };

            ViewData["TipoTelefonos"] = await _context.TiposTelefono.ToListAsync();
            ViewData["TipoDirecciones"] = await _context.TiposDireccion.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditarPerfil(UsuarioPerfilViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Update(model.Usuario);
                _context.Update(model.Persona);
                _context.UpdateRange(model.Direcciones);
                _context.UpdateRange(model.Telefonos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            ViewData["TipoTelefonos"] = await _context.TiposTelefono.ToListAsync();
            ViewData["TipoDirecciones"] = await _context.TiposDireccion.ToListAsync();

            return View(model);
        }
    }
}
