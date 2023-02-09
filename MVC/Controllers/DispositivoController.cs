using Dominio.Entidades;
using Dominio.Exepciones;
using Dominio.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ObliProgV5.Controllers
{
    public class DispositivoController : Controller
    {
        private readonly DispositivoServicio DS;
        private readonly EstacionServicio ES;
        private readonly TipoDispositivoServicio TDS;
        private readonly UsuarioServicio US;

        public DispositivoController(DispositivoServicio dS, EstacionServicio eS, TipoDispositivoServicio tdS, UsuarioServicio uS)
        {
            this.DS = dS;
            this.ES = eS;
            this.TDS = tdS;
            this.US = uS;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Dispositivo> dispositivos = new List<Dispositivo>();
            if (User.IsInRole("Supervisor"))
            {
                var supervisor = US.BuscarPorNombre(User.Identity.Name);
                var estaciones = ES.ListarEstaciones().Where(z => z.IdSupervisor == supervisor.Id).ToList();
                var dispositivosTrucho = DS.ListarDispositivos();
                foreach(var e in estaciones)
                {
                    foreach(var d in dispositivosTrucho)
                    {
                        if (e.Id == d.IdEstacion)
                        {
                            dispositivos.Add(d);
                        }
                    }
                }
            }
            else
            {
                dispositivos = DS.ListarDispositivos();
            }
            return View(dispositivos);
        }

        [HttpGet]
        public IActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dispositivo = DS.BuscarPorId(id.Value);
            if (dispositivo == null)
            {
                return NotFound();
            }
            return View(dispositivo);
        }

        [HttpGet]
        public IActionResult Alta()
        {
            List<Estacion> estaciones;
            if (User.IsInRole("Supervisor"))
            {
               
                var supervisor = US.BuscarPorNombre(User.Identity.Name);
                estaciones = ES.ListarEstaciones().Where(x => x.IdSupervisor == supervisor.Id).ToList();
            }
            else
            {
                estaciones = ES.ListarEstaciones();
            }
            
            var tipoDispositivos = TDS.ListarTipoDispositivo();
            ViewBag.TipoDispositivos = tipoDispositivos;
            ViewBag.Estaciones = estaciones;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alta(Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DS.AgregarDispositivo(dispositivo);
                    return RedirectToAction(nameof(Index));
                }
                catch (DominioExepciones ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            

            var estaciones = ES.ListarEstaciones();
            ViewBag.Estaciones = estaciones;
            var tipoDispositivos = TDS.ListarTipoDispositivo();
            ViewBag.TipoDispositivos = tipoDispositivos;
            return View(dispositivo);
        }

        [HttpGet]

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var dispositivo = DS.BuscarPorId(id.Value);
            if (dispositivo == null)
            {
                return NotFound();
            }
            var estaciones = ES.ListarEstaciones();
            ViewBag.Estaciones = estaciones;
            var tipoDispositivos = TDS.ListarTipoDispositivo();
            ViewBag.TipoDispositivos = tipoDispositivos;
            return View(dispositivo);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Editar(Dispositivo dispositivo)
        {

            Dispositivo dispositivoOriginal = DS.BuscarPorId(dispositivo.Id);
            dispositivoOriginal.Detalle = dispositivo.Detalle;
            dispositivoOriginal.IdTipo = dispositivo.IdTipo;
            dispositivoOriginal.Tipo = TDS.BuscarPorId(dispositivo.IdTipo);
            dispositivoOriginal.Estacion = ES.BuscarPorId(dispositivo.IdEstacion);    
            dispositivoOriginal.IdEstacion = dispositivo.IdEstacion;    
            dispositivoOriginal.Nombre = dispositivo.Nombre;
            dispositivoOriginal.FecModificacion = System.DateTime.Now;
            dispositivoOriginal.FecAlta = dispositivo.FecAlta;
            dispositivoOriginal.Estado = dispositivo.Estado;

            if (ModelState.IsValid)
            {
                try
                {
                    DS.ActualizarDispositivo(dispositivoOriginal);
                    return RedirectToAction(nameof(Index));
                }
                catch (DominioExepciones ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            var estaciones = ES.ListarEstaciones();
            ViewBag.Estaciones = estaciones;
            var tipoDispositivos = TDS.ListarTipoDispositivo();
            ViewBag.TipoDispositivos = tipoDispositivos;
            return View(dispositivoOriginal);
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var dispositivo = DS.BuscarPorId(id.Value);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        [HttpPost, ActionName("Eliminar")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ConfirmarEliminar(int id)
        {
            var dispositivo = DS.BuscarPorId(id);
            DS.EliminarDispositivo(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
