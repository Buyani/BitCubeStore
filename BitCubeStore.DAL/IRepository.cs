using BitCubeStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCubeStore.DAL
{
  public interface IRepository
  {
    void AddProduct(ProductPurchase product);
    ICollection<ProductPurchase> GetAllProducts();
    void Updateproduct(ProductPurchase product);


    void AddSellProduct(ProductSold productsSellOrder);
    void UpdateSoldProduct(ProductSold product);
    ICollection<ProductSold> GetAllSoldProducts();
  }
}
