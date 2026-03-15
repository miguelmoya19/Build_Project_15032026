using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Software.Application.Interfaces;
using Software.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Software.Infraestructure.Middleware
{
    public class AuditInterceptor : SaveChangesInterceptor
    {

        private readonly ICurrentUserContext _currentUser;

        public AuditInterceptor(ICurrentUserContext currentUset)
        {
            this._currentUser = currentUset;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
        {

            //var context = eventData.Context;

            //if (context == null)
            //    return base.SavingChangesAsync(eventData, result, cancellationToken);

            //var auditEntries = context.ChangeTracker
            //    .Entries()
            //    .Where(e =>
            //        e.State == EntityState.Added ||
            //        e.State == EntityState.Modified ||
            //        e.State == EntityState.Deleted)
            //    .ToList();

            //foreach (var entry in auditEntries)
            //{
            //    if (entry.Entity is BaseAudit)
            //        continue;

            //    var json = JsonSerializer.Serialize(
            //        entry.CurrentValues.ToObject());

            //    context.Set<BaseAudit>().Add(new BaseAudit
            //    {
            //        Action = entry.State.ToString(),
            //        TableName = entry.Metadata.GetTableName() ?? "",
            //        Data = json ?? null,
            //        Username = _currentUser.Username ?? "",
            //        IpAddress = _currentUser.Ip
            //    });
            //}

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

    }
}
