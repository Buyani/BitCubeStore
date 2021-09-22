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
    public ProductsSoldResults SellProductsFromInventory(ProductsSellOrder itemsSoldOrder)
    {
      var productsoldresults = new ProductsSoldResults();
      var productsold = getSoldproduct(itemsSoldOrder);
      if (productsold != null)
      {
        if (CheckItemAvailability(itemsSoldOrder))
        {
          productsold.Quantity += itemsSoldOrder.Quantity;
          repository.UpdateSoldProduct(productsold);
          productsoldresults = SellResults(productsold, itemsSoldOrder.SellPrice, true);
        }
        else
        {
          productsoldresults = SellResults(productsold, itemsSoldOrder.SellPrice, false);
        }
      }
      else
      {
        productsold=repository.AddSellProduct(mapper.Map<ProductSold>(itemsSoldOrder));
        productsoldresults = SellResults(productsold, itemsSoldOrder.SellPrice, true);
      }
      return productsoldresults;
    }

    private ProductPurchase ProductExist(ProductsPurchaseOrder productpurchase)
    {
      var product = repository.GetAllProducts().FirstOrDefault(product => product.ProductName.Equals(productpurchase.ProductName)
         && product.UnitPrice.Equals(productpurchase.UnitPrice) && product.ProductTypeId.Equals(productpurchase.ProductTypeId));

      if (product != null)
        return product;

      return null;
    }

    private bool CheckItemAvailability(ProductsSellOrder itemsSoldOrder)
    {
      var soldproduct = repository.GetAllSoldProducts().FirstOrDefault(product =>
                        product.ProductPurchaseId.Equals(itemsSoldOrder.ProductPurchaseId)
                                      && product.ProductPurchase.UnitPrice.Equals(itemsSoldOrder.UnitPrice));

      var purchasedproduct = repository.GetAllProducts().FirstOrDefault(product=>product.ProductPurchaseId.Equals(itemsSoldOrder.ProductPurchaseId));

      if ((purchasedproduct.Quantity - itemsSoldOrder.Quantity) <= soldproduct.Quantity)
      {
        return false;
      }

      return true;
    }
    private ProductSold getSoldproduct(ProductsSellOrder itemsSoldOrder)
    {
      var product = repository.GetAllSoldProducts().FirstOrDefault(product =>
                         product.ProductPurchaseId.Equals(itemsSoldOrder.ProductPurchaseId)
                                       && product.ProductPurchase.UnitPrice.Equals(itemsSoldOrder.UnitPrice));

      return product;
    }
    private ProductsSoldResults SellResults(ProductSold productsSell, decimal Sellingprice, bool sold)
    {
      return new ProductsSoldResults
      {
        SellingPrice = Sellingprice,
        ProductName = productsSell.ProductPurchase.ProductName,
        ProductSold = sold,
        Quantity = productsSell.Quantity
      };
    }

    public InventorySummary InventorySummary()
    {
      var productlist = new List<ProductsPurchaseOrder>();

      foreach(var product in repository.GetAllProducts().Select(mapper.Map<ProductPurchase, ProductsPurchaseOrder>).ToList())
      {
        productlist.Add(product);
      }
      return new InventorySummary
      {
        InventoryProducts = productlist
      };

    }

    public InventoryItemSummary GetInventoryItemSummary(ProductType stockType)
    {
      var inventory = new InventoryItemSummary();

      foreach (var product in repository.GetAllProducts().Where(product => product.ProductTypeId.Equals(stockType.ProductTypeId)).Select(mapper.Map<ProductPurchase, ProductsPurchaseOrder>).ToList())
      {
        inventory.InventoryProducts.Add(product);
      }

      inventory.AveragePrice = inventory.InventoryProducts.Select(price => price.UnitPrice).Sum() / inventory.InventoryProducts.Count();

      return inventory;

    }
  }
}
