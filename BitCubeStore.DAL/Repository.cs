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
      context.SaveChanges();
    }

    public ProductSold AddSellProduct(ProductSold productsSellOrder)
    {
      context.SolProducts.Add(productsSellOrder);
      context.SaveChanges();

      return productsSellOrder;
    }
    public void UpdateSoldProduct(ProductSold product)
    {
      context.SolProducts.Update(product);
      context.SaveChanges();
    }
    public ICollection<ProductPurchase> GetAllSoldProducts()
    {
      return context.ProductsPurchaseOrders.ToList();
    }

    ICollection<ProductSold> IRepository.GetAllSoldProducts()
    {
      return context.SolProducts.ToList();
    }

    public ICollection<TypeProduct> GetAllTypes()
    {
      return context.ProductTypes.ToList();
    }
  }
}
