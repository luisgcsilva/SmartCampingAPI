using System;
using System.Collections.Generic;

namespace SmartCamping.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public int AlojamentoId { get; set; }

    public int MetodoId { get; set; }

    public int EstadoId { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public decimal PrecoNoite { get; set; }

    public decimal PrecoTotal { get; set; }

    public decimal Pagamento { get; set; }

    public virtual Alojamento Alojamento { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual EstadoReserva Estado { get; set; } = null!;

    public virtual MetodoPagamento Metodo { get; set; } = null!;
}
