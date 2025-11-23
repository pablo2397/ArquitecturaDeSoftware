using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdDepartamento { get; set; }
    
    public bool Estado { get; set; }
    [JsonIgnore]
    public virtual ICollection<Asesor> Asesors { get; } = new List<Asesor>();
    [JsonIgnore]
    public virtual Departamento? IdDepartamentoNavigation { get; set; }
}
