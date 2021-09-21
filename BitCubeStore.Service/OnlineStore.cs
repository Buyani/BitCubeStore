using AutoMapper;
using BitCubeStore.DAL;
using BitCubeStore.DAL.Entities;
using BitCubeStore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitCubeStore.Service
{
  public class OnlineStore : IOnlineStore
  {
    private IRepository repository;
    private readonly IMapper mapper;
    public OnlineStore(IRepository repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }
    public void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder)
    {
      var searchedproduct = ProductExist(purchaseOrder);
      if (searchedproduct!=null)
      {
        searchedproduct.Quantity += purchaseOrder.Quantity;
      }
      else
      {
        repository.AddProduct(mapper.Map<ProductPurchase>(purchaseOrder));
      }
    }


    private ProductPurchase ProductExist(ProductsPurchaseOrder productpurchase)
    {
      var product = repository.GetAllProducts().FirstOrDefault(product => product.ProductName.Equals(productpurchase.ProductName)
         && product.UnitPrice.Equals(productpurchase.UnitPrice) && product.TypeProductId.Equals(productpurchase.ProductTypeId));

      if (product != null)
        return product;

      return null;


    }
  }
}
