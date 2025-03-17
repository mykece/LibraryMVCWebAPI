﻿using HS_14_MVC.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncDeletableRepository<TEntity>:IAsyncRepository where TEntity : BaseEntity
    {
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
