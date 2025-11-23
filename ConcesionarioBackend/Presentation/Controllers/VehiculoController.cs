using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Concesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculoController : BaseController<Vehiculo>
    {
        public VehiculoController(IServiceBase<Vehiculo> serviceBase) : base(serviceBase)
        {
            
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            Vehiculo vehiculo = _serviceBase.GetVehiculo(id);
            return base.Delete(vehiculo);
        }
    }
}