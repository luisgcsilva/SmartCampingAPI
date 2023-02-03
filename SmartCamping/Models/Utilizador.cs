using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartCamping.Models;

public partial class Utilizador
{
    public int UtilizadorId { get; set; }

    public int TipoUtilizadorId { get; set; }

    public string Email { get; set; } = null!;

    public string PalavraPasse { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
    [JsonIgnore]
    public virtual ICollection<Funcionario> Funcionarios { get; } = new List<Funcionario>();
    public virtual TipoUtilizador TipoUtilizador { get; set; } = null!;
}
