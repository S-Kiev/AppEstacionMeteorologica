using Dominio.Entidades;
using Dominio.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ObliProgApi.Controllers
{
   
    [ApiController]
    public class TipoDispositivoController : ControllerBase
    {
        private readonly DispositivoServicio DS;

        public TipoDispositivoController( DispositivoServicio dS)
        {
            
            this.DS = dS;
        }


        [Route("api/[controller]/{id:int}/dispositivos")]
        [HttpGet]
        public ActionResult<List<Dispositivo>> GetDispositivos(int? id)
        {
            List<Dispositivo> dispositivos= DS.ListarDispositivos().Where(x => x.IdTipo == id.Value).ToList();
            return dispositivos;
        }
    }
}
