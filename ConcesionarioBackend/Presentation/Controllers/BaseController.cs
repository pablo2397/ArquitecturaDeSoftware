using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : ControllerBase where T : class, new()
    {
        
        public IServiceBase<T> _serviceBase;
        public BaseController(IServiceBase<T> serviceBase)
        {
            this._serviceBase = serviceBase;
        }

        [HttpPost("Create")]
        public int Create(T objeto)
        {
            return _serviceBase.Create(objeto);
        }

        [HttpGet("GetAll")]
        public List<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        [HttpPut("Edit")]
        public int Edit(T objeto)
        {
            return _serviceBase.Edit(objeto);
        }
        protected int Delete(T objeto)
        {
            return _serviceBase.Delete(objeto);
        }
    }
}
