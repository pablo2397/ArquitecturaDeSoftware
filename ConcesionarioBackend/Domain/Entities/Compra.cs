using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdVehiculo { get; set; }
        public int IdAsesor { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }

        // Relaciones (Navigation Properties)
        [JsonIgnore]
        public virtual Vehiculo? IdVehiculoNavegation { get; set; }
        [JsonIgnore]
        public virtual Asesor? IdAsesorNavegation { get; set; }
        [JsonIgnore]
        public virtual Cliente? IdClienteNavegation { get; set; }
    }
}
