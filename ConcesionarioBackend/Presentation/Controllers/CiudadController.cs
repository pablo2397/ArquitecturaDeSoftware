using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Concesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadController : BaseController<Ciudad>
    {
        public CiudadController(IServiceBase<Ciudad> serviceBase) : base(serviceBase)
        {

        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            Ciudad ciudad = _serviceBase.GetCiudad(id);
            return base.Delete(ciudad);
        }
    }
}
