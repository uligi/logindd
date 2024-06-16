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
            var generos = await _context.Genero.ToListAsync();
            var tipoTelefonos = await _context.Tipo_Telefono.ToListAsync();
            var tipoDirecciones = await _context.Tipo_Direccion.ToListAsync();
            var tipoCorreos = await _context.Tipo_Correo.ToListAsync();

            var model = new UsuarioRegistroViewModel
            {
                Genero = generos,
                Direcciones = new List<Direccion> { new Direccion() },
                Telefonos = new List<Telefono> { new Telefono() },
                Correos = new List<Correo> { new Correo() }
            };

            ViewData["TipoTelefonos"] = tipoTelefonos;
            ViewData["TipoDirecciones"] = tipoDirecciones;
            ViewData["TipoCorreos"] = tipoCorreos;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(UsuarioRegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Usuario.TipoUsuarioID = 3; // Asignar tipo de usuario predeterminado (cliente)
                _context.Persona.Add(model.Persona);
                await _context.SaveChangesAsync();

                model.Usuario.PersonaID = model.Persona.PersonaID;
                _context.Usuario.Add(model.Usuario);
                await _context.SaveChangesAsync();

                foreach (var direccion in model.Direcciones)
                {
                    direccion.UsuarioID = model.Usuario.UsuarioID;
                    _context.Direccion.Add(direccion);
                }

                foreach (var telefono in model.Telefonos)
                {
                    telefono.PersonaID = model.Persona.PersonaID;
                    _context.Telefono.Add(telefono);
                }

                // Añadir el correo del usuario a la tabla Correo
                var correo = new Correo
                {
                    PersonaID = model.Persona.PersonaID,
                    DireccionCorreo = model.Usuario.Email,
                    TipoCorreoID = 1 // Asumiendo que 1 es el ID para el tipo de correo predeterminado
                };
                _context.Correo.Add(correo);

                foreach (var correoExtra in model.Correos)
                {
                    correoExtra.PersonaID = model.Persona.PersonaID;
                    _context.Correo.Add(correoExtra);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            model.Genero = await _context.Genero.ToListAsync();
            ViewData["TipoTelefonos"] = await _context.Tipo_Telefono.ToListAsync();
            ViewData["TipoDirecciones"] = await _context.Tipo_Direccion.ToListAsync();
            ViewData["TipoCorreos"] = await _context.Tipo_Correo.ToListAsync();

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
                var usuario = await _context.Usuario
                    .Include(u => u.Persona)
                    .Include(u => u.Tipo_Usuario) // Incluye la propiedad de navegación Tipo_Usuario
                    .FirstOrDefaultAsync(u =>
                        (u.Email == model.CorreoONombreUsuario || u.NombreUsuario == model.CorreoONombreUsuario) &&
                        u.Contraseña == model.Contraseña);

                if (usuario != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Email),
                        new Claim(ClaimTypes.Role, usuario.Tipo_Usuario.Nombre) // Usar el nombre del tipo de usuario como rol
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
            var usuario = await _context.Usuario
                .Include(u => u.Persona)
                .Include(u => u.Direccion)
                .Include(u => u.Telefono)
                .FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

            if (usuario == null)
            {
                return NotFound();
            }

            var genero = await _context.Genero.ToListAsync();

            var model = new UsuarioPerfilViewModel
            {
                Usuario = usuario,
                Persona = usuario.Persona,
                Direcciones = usuario.Direccion.ToList(),
                Telefonos = usuario.Telefono.ToList(),
                Genero = genero
            };

            ViewData["TipoTelefonos"] = await _context.Tipo_Telefono.ToListAsync();
            ViewData["TipoDirecciones"] = await _context.Tipo_Direccion.ToListAsync();

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

            ViewData["TipoTelefonos"] = await _context.Tipo_Telefono.ToListAsync();
            ViewData["TipoDirecciones"] = await _context.Tipo_Direccion.ToListAsync();

            return View(model);
        }
    }
}
