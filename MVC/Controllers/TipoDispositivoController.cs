using Dominio.Entidades;
using Dominio.Exepciones;
using Dominio.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ObliProgV5.Controllers
{
    public class TipoDispositivoController : Controller
    {
        private readonly TipoDispositivoServicio tds;

        public TipoDispositivoController(TipoDispositivoServicio tds)
        {
            this.tds = tds;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(tds.ListarTipoDispositivo());
        }

        [HttpGet]
        public IActionResult Detalles(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var tipoDispositivo = tds.BuscarPorId(id.Value);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }
            return View(tipoDispositivo);
        }

        [HttpGet]
        public IActionResult Alta()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alta([Bind("Nombre,Descripcion")] TipoDispositivo tipoDispositivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tds.AgregarTipoDespositivo(tipoDispositivo);
                    return RedirectToAction(nameof(Index));
                }
                catch(DominioExepciones ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                
            }
            return View(tipoDispositivo);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var tipoDispositivo = tds.BuscarPorId(id.Value);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }
            return View(tipoDispositivo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, TipoDispositivo tipoDispositivo)
        {
            if(id != tipoDispositivo.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    tds.ActualizarTipoDispositivo(tipoDispositivo);
                }
                catch(DominioExepciones ex)
                {
                    throw new DominioExepciones(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDispositivo);
        }
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var tipoDispositivo = tds.BuscarPorId(id.Value);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }
            return View(tipoDispositivo);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEliminar(int? id)
        {
            tds.EliminarTipoDispositivo(id.Value);
            return RedirectToAction(nameof(Index));
        }
      
    }
}
