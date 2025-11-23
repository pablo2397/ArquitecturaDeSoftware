using Application.Interfaces;
using Concesionario.Controllers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : BaseController<Cliente>
    {
        public ClienteController(IServiceBase<Cliente> serviceBase) : base(serviceBase)
        {
            
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            Cliente cliente = _serviceBase.GetCliente(id);
            return base.Delete(cliente);
        }
    }
}
