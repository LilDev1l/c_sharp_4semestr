using lab11.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Data
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConection")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
