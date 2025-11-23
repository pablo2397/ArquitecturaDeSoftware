namespace Domain.Entities;

public partial class TipoVehiculo
{
    public int IdTipovehiculo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }
}
