using BitCubeStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public ICollection<ProductPurchase> GetAllProducts()
    {
      return context.ProductsPurchaseOrders.ToList();
    }

    public void Updateproduct(ProductPurchase product)
    {
      context.ProductsPurchaseOrders.Update(product);
    }

    public void AddSellProduct(ProductSold productsSellOrder)
    {
      context.SolProducts.Add(productsSellOrder);
      context.SaveChanges();
    }
    public void UpdateSoldProduct(ProductSold product)
    {
      context.SolProducts.Update(product);
    }
    public ICollection<ProductSold> GetAllSoldProducts()
    {
      return context.SolProducts.ToList();
    }
  }
}
