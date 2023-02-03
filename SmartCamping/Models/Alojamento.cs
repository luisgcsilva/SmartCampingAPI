using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartCamping.Models;

public partial class Alojamento
{
    public int AlojamentoId { get; set; }

    public int TipoAlojamentoId { get; set; }

    public string Descricao { get; set; } = null!;

    public int Capacidade { get; set; }
    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; } = new List<Reserva>();
    [JsonIgnore]
    public virtual TipoAlojamento TipoAlojamento { get; set; } = null!;
}
