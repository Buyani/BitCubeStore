using BitCubeStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCubeStore.DAL
{
  public class Repository : IRepository
  {
    private BitCubeStoreDataContext context;

    public Repository(BitCubeStoreDataContext context)
    {
      this.context = context;
    }
    public void AddProduct(ProductPurchase product)
    {
      context.ProductsPurchaseOrders.Add(product);
      context.SaveChanges();
    }
  }
}
