﻿using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.AppContext;
using HS_14_MVC.Infrastructure.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.PublisherRepositories
{
    public class PublisherRepository : EFBaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
