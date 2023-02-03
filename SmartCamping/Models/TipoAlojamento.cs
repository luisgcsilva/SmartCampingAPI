using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartCamping.Models;

public partial class TipoAlojamento
{
    public int TipoAlojamentoId { get; set; }

    public string Tipo { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Alojamento> Alojamentos { get; } = new List<Alojamento>();
}
