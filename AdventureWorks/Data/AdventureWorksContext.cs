using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Models;

namespace AdventureWorks.Data
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext (DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }

        public DbSet<AdventureWorks.Models.Product> Products { get; set; } = default!;

        public DbSet<AdventureWorks.Models.Customer> Customer { get; set; } = default!;
    }
}
