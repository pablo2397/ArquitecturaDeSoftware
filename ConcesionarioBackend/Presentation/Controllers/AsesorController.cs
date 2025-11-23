using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Concesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsesorController : BaseController<Asesor>
    {
        public AsesorController(IServiceBase<Asesor> serviceBase) : base(serviceBase)
        {

        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            Asesor asesor  = _serviceBase.GetAsesor(id);
            return base.Delete(asesor);
        }
    }
}
