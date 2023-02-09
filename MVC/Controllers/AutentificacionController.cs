using Dominio.Entidades;
using Dominio.Exepciones;
using Dominio.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

using System.Threading.Tasks;

namespace ObliProgV5.Controllers
{
    public class AutentificacionController : Controller
    {
        private readonly UsuarioServicio US;

        public AutentificacionController(UsuarioServicio uS)
        {
            US = uS;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login([Bind("NomUsuario,Pass")]Usuario usuario)
        {
            try 
            { 
                Usuario usuarioIdentificado = US.logearUsuario(usuario.NomUsuario, usuario.Pass);
                if (usuarioIdentificado != null && usuarioIdentificado.NomUsuario!="...")
                {
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,usuarioIdentificado.NomUsuario),
                    new Claim(ClaimTypes.Role,usuarioIdentificado.Rol),
                };
                    var claimIdentidad = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentidad));
                   
                    return RedirectToAction("Index", "Inicio");
                }
                else
                {
                    return RedirectToAction(nameof(AccesoDenegado));
                }
            }
              catch (DominioExepciones ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        [HttpGet]   
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Autentificacion");
        }
      
    }
}
