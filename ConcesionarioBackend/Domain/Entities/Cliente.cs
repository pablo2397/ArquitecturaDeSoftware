using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Apellido { get; set; }

        public string TipoDocumento { get; set; } = string.Empty;

        public string NumeroDocumento { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        [JsonIgnore]
        public virtual Compra? Compra { get; set; }
    }
}
