using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }
    [JsonIgnore]
    public virtual ICollection<Asesor> Asesors { get; } = new List<Asesor>();
    [JsonIgnore]
    public virtual ICollection<Ciudad> Ciudads { get; } = new List<Ciudad>();
}
