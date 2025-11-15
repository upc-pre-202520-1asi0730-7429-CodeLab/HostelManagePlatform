using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace HostelManagerPlatform.API.Users.Domain.Model.Aggregates;

public partial class User : IEntityWithCreatedUpdatedDate
{
    [Column ("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column ("UpdateAt")] public DateTimeOffset? UpdatedDate { get; set; }
}