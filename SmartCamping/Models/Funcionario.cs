using System;
using System.Collections.Generic;

namespace SmartCamping.Models;

public partial class Funcionario
{
    public int FuncionarioId { get; set; }

    public int UtilizadorId { get; set; }

    public string Nome { get; set; } = null!;

    public int Telemovel { get; set; }

    public string Departamento { get; set; } = null!;

    public virtual Utilizador Utilizador { get; set; } = null!;
}
