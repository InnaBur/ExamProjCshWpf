using PruefungProj_LifeOrganaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace PruefungProj_LifeOrganaiser.Repository
{
    internal class LifeOrganiserDbContext : DbContext
    {
        public LifeOrganiserDbContext() : base("LifeOrganiserDb2")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LifeOrganiserDbContext>());
        }

        public DbSet<Trip> Trips { get; set; }

    }
}
