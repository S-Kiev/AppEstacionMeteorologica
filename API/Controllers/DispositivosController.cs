using Dominio.Entidades;
using Dominio.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ObliProgApi.Controllers
{
    
    [ApiController]
    public class DispositivosController : ControllerBase
    {
        private readonly DispositivoServicio DS;

        public DispositivosController(DispositivoServicio dS)
        {
            this.DS = dS;
        }

        [Route("api/[controller]/{id:int}/{valor:float}/datos")]
        [HttpPost]
        public ActionResult<Dispositivo> PostDispositivo(int? id,float valor)
        {
            var dispositivo = DS.BuscarPorId(id.Value);
            dispositivo.Valor = valor;
            DS.ActualizarDispositivo(dispositivo);
            return dispositivo;
        }
    }
}
