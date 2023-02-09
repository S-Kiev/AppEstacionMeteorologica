using Dominio.Entidades;
using Dominio.Exepciones;

using Dominio.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ObliProgV5.Controllers
{
    
    public class EstacionController : Controller
    {
        private readonly EstacionServicio ES;
        private readonly UsuarioServicio US;
        private readonly DispositivoServicio DS;

        public EstacionController(EstacionServicio eS, UsuarioServicio uS, DispositivoServicio dS)
        {
            this.ES = eS;
            this.US = uS;
            this.DS = dS;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(ES.ListarEstaciones());
        }

        [HttpGet]
        public IActionResult Detalles(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var estacion = ES.BuscarPorId(id.Value);
            if (estacion == null)
            {
                return NotFound();
            }
            return View(estacion); 
        }

        [HttpGet]
        public IActionResult Alta()
        {
            var Supervisores = US.ListarUsuario().Where(x => x.Rol == "Supervisor");
            ViewBag.Supervisores = Supervisores;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alta(Estacion est)
        {
            if (ModelState.IsValid) 
            { 
                try
                {
                    ES.AgregarEstacion(est);
                    return RedirectToAction(nameof(Index));
                }
                catch(DominioExepciones ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
             }
            var Supervisores = US.ListarUsuario().Where(x => x.Rol == "Supervisor");
            ViewBag.Supervisores = Supervisores;
            return View(est);
        }

        [HttpGet]
        
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var estacion = ES.BuscarPorId(id.Value);
            if(estacion==null)
            {
                return NotFound();
            }
            var Supervisores = US.ListarUsuario().Where(x => x.Rol == "Supervisor");
            ViewBag.Supervisores = Supervisores;
            return View(estacion);  
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Editar( Estacion est)
        {
            
            Estacion estOriginal = ES.BuscarPorId(est.Id);
            estOriginal.Longitud= est.Longitud; 
            estOriginal.Latitud= est.Latitud;
            estOriginal.Nombre= est.Nombre; 
            estOriginal.Supervisor= est.Supervisor;
            estOriginal.IdSupervisor = est.IdSupervisor;
            if (ModelState.IsValid)
            {
                try
                {
                    ES.ActualizarEstacion(estOriginal);
                    return RedirectToAction(nameof(Index));
                }
                catch (DominioExepciones ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            var Supervisores = US.ListarUsuario().Where(x => x.Rol == "Supervisor");
            ViewBag.Supervisores = Supervisores;
            return View(estOriginal);
        }

        [HttpGet]

        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var estacion = ES.BuscarPorId(id.Value);
            if (estacion == null)
            {
                return NotFound();
            }

            return View(estacion);
        }

        [HttpPost, ActionName("Eliminar")]
        [AutoValidateAntiforgeryToken]

        public IActionResult ConfirmarEliminar(int id)
        {
            var estacion = ES.BuscarPorId(id);
            ES.EliminarEstacion(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DispositivosPorEstacion(int? id)
        {
            var dispositivos = DS.ListarDispositivos().Where(x => x.IdEstacion == id.Value).ToList();
            var estacion = ES.BuscarPorId(id.Value);
            ViewBag.Estacion = estacion;
            return View(dispositivos);
        }

    }
}
