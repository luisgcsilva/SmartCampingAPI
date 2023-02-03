using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartCamping.Models;

public partial class EstadoReserva
{
    public int EstadoReservaId { get; set; }

    public string Estado { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; } = new List<Reserva>();
}
