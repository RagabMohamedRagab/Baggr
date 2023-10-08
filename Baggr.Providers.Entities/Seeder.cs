using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities
{
    public class Seeder
    {
        private readonly IProvidersContext _ctx;

        public Seeder(IProvidersContext ctx)
        {
            this._ctx = ctx;
        }
        public void Seed()
        {
            _ctx.Instance.Database.Migrate();
            _ctx.Instance.Database.EnsureCreated();
            _ctx.Instance.SaveChanges();
        }

    }
}
