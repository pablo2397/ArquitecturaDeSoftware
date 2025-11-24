//using Application.Interfaces;
//using Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace Concesionario.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class TipoVehiculoController : BaseController<TipoVehiculo>
//    {
//        public TipoVehiculoController(IServiceBase<TipoVehiculo> serviceBase) : base(serviceBase)
//        {

//        }

//        [HttpDelete("{id}")]
//        public int Delete(int id)
//        {
//            TipoVehiculo tipoVehiculo = _serviceBase.GetTipoVehiculo(id);
//            return base.Delete(tipoVehiculo);
//        }
//    }
//}
