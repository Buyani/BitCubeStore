using BitCubeStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCubeStore.DAL
{
  public class BitCubeStoreDataContext:DbContext
  {
    public BitCubeStoreDataContext() { }

    public BitCubeStoreDataContext(DbContextOptions<BitCubeStoreDataContext> options)
      :base(options)
    { }

    /// <summary>
    /// initialize entities to database
    /// </summary>
    public DbSet<ProductPurchase> ProductsPurchaseOrders { get; set; }
    public DbSet<TypeProduct> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
    }
  }
}
