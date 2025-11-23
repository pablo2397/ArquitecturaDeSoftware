using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class Asesor
{
    public int IdAsesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public bool? Estado { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdCiudad { get; set; }
    [JsonIgnore]
    public virtual Ciudad? IdCiudadNavigation { get; set; }
    [JsonIgnore]
    public virtual Departamento? IdDepartamentoNavigation { get; set; }
    [JsonIgnore]
    public virtual Compra Compra { get; set; } = null!;
}
