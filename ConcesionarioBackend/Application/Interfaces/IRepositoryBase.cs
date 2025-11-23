using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        int Create(T objeto);
        List<T> GetAll();
        int Edit(T objeto);
        int Delete(T objeto);
        TipoVehiculo GetTipoVehiculo(int id);
        Asesor GetAsesor(int id);
        Ciudad GetCiudad(int id);
        Departamento GetDepartamento(int id);
        Vehiculo GetVehiculo(int id);
        Cliente GetCliente(int id);
        //Usuarios GetUsuarios(int id);
        //Usuarios VerificarUsuario(string usuario, string clave);
    }
}
