using Microsoft.AspNetCore.Mvc;
using Layer.Entity;
using Layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {

        [HttpGet("Listar")]
        public List<EmpleadoEntity> Listar()
        {
            EmpleadoDomain oEmpleadoDomain = new EmpleadoDomain();
            return oEmpleadoDomain.Listar();
        }

        [HttpPost("Filtrar")]
        public List<EmpleadoEntity> Filtrar([FromBody] EmpleadoEntity entidad)
        {
            EmpleadoDomain oEmpleadoDomain = new EmpleadoDomain();
            return oEmpleadoDomain.Filtrar(entidad);
        }

        [HttpPost("Grabar")]
        public string Registrar([FromBody] EmpleadoEntity entidad)
        {
            EmpleadoDomain oEmpleadoDomain = new EmpleadoDomain();
            return oEmpleadoDomain.Registrar(entidad);
        }

        [HttpPut("Actualizar")]
        public string Modificar([FromBody] EmpleadoEntity entidad)
        {
            EmpleadoDomain oEmpleadoDomain = new EmpleadoDomain();
            return oEmpleadoDomain.Modificar(entidad);
        }

        [HttpDelete("Eliminar")]
        public string Eliminar([FromBody] EmpleadoEntity entidad)
        {
            EmpleadoDomain oEmpleadoDomain = new EmpleadoDomain();
            return oEmpleadoDomain.Eliminar(entidad);
        }

    }
}
