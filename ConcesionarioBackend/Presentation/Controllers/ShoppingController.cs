using Application.Interfaces;
using Concesionario.Controllers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : BaseController<Compra>
    {
        public ShoppingController(IServiceBase<Compra> serviceBase) : base(serviceBase)
        {
            
        }
    }
}
