using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartCamping.Models;

public partial class MetodoPagamento
{
    public int MetodoPagamentoId { get; set; }

    public string Metodo { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; } = new List<Reserva>();
}
