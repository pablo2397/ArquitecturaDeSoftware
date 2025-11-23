using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Concesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : BaseController<Departamento>
    {
        public DepartamentoController(IServiceBase<Departamento> serviceBase) : base(serviceBase)
        {

        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            Departamento departamento = _serviceBase.GetDepartamento(id);
            return base.Delete(departamento);
        }
    }
}
