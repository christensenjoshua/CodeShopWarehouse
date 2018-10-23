using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeShopWarehouse.Entities.Models;

namespace CodeShopWarehouse.Web.Models
{
    public class CodeShopWarehouseWebContext : DbContext
    {
        public CodeShopWarehouseWebContext (DbContextOptions<CodeShopWarehouseWebContext> options)
            : base(options)
        {
        }

        public DbSet<CodeShopWarehouse.Entities.Models.Order> Order { get; set; }
    }
}
