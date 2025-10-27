
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace HostelManager.API.Hotels.Domain.Model.Aggregates;

/// <summary>
///     Clase base para la auditoría de un agregado, implementando las fechas de creación y actualización.
/// </summary>
public partial class HotelSource : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}