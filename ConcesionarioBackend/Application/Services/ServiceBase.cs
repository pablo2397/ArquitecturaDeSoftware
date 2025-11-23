using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class, new()
    {
        public IRepositoryBase<T> repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }
        public int Create(T objeto)
        {
            return repositoryBase.Create(objeto);
        }
        public List<T> GetAll()
        {
            return repositoryBase.GetAll();
        }
        public int Edit(T objeto)
        {
            return repositoryBase.Edit(objeto);
        }
        public int Delete(T objeto)
        {
            return repositoryBase.Delete(objeto);
        }
        public Asesor GetAsesor(int id)
        {
            return repositoryBase.GetAsesor(id);
        }
        public TipoVehiculo GetTipoVehiculo(int id)
        {
            return repositoryBase.GetTipoVehiculo(id);
        }
        public Ciudad GetCiudad(int id)
        {
            return repositoryBase.GetCiudad(id);
        }
        public Departamento GetDepartamento(int id)
        {
            return repositoryBase.GetDepartamento(id);
        }
        public Vehiculo GetVehiculo(int id)
        {
            return repositoryBase.GetVehiculo(id);
        }
        public Cliente GetCliente(int id)
        {
            return repositoryBase.GetCliente(id);
        }
        //public Usuarios GetUsuarios(int id)
        //{
        //    return repositoryBase.GetUsuarios(id);
        //}
        //public bool VerificarUsuario(string usuario, string clave)
        //{
        //    if (repositoryBase.VerificarUsuario(usuario, clave) != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
