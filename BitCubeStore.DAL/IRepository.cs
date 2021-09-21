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
  }
}
