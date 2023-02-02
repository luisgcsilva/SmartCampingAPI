﻿using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface ITipoAlojamentoRepository
    {
        ICollection<TipoAlojamento> GetTipoAlojamentos();
        TipoAlojamento GetTipoAlojamento(int tipoAlojamentoId);
        ICollection<Reserva> GetReservasPorTipoAlojamento(int tipoAlojamentoId);
        bool TipoAlojamentoExists(int tipoAlojamentoId);
    }
}
