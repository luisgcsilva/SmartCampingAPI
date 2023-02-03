using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartCamping.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public int UtilizadorId { get; set; }

    public string Nome { get; set; } = null!;

    public int Telemovel { get; set; }

    public int Nif { get; set; }

    public string Morada { get; set; } = null!;

    public string CodPostal { get; set; } = null!;

    public string Localidade { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; } = new List<Reserva>();

    public virtual Utilizador Utilizador { get; set; } = null!;
}
