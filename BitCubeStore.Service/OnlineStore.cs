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
      if (searchedproduct != null)
      {
        searchedproduct.Quantity += purchaseOrder.Quantity;
        repository.Updateproduct(searchedproduct);
      }
      else
      {
        repository.AddProduct(mapper.Map<ProductPurchase>(purchaseOrder));
      }
    }

    public ProductsSoldResults SellProductsFromInventory(ProductsSellOrder itemsSoldOrder)
    {
      var soldproduct = getSoldproduct(itemsSoldOrder);
      var productsoldresults = new ProductsSoldResults();
      if (soldproduct != null)
      {
        if (CheckItemAvailability(itemsSoldOrder))
        {
          soldproduct.Quantity += itemsSoldOrder.Quantity;
          repository.UpdateSoldProduct(soldproduct);
          productsoldresults.Message = soldproduct.Quantity+itemsSoldOrder.Quantity+" Of this products have been sold";
        }
        else
        {
          productsoldresults.Message = "Could not sell product because a quantity of "+soldproduct.Quantity+" in stock equals to number of sold products";
        }
      }
      else
      {
        repository.AddSellProduct(mapper.Map<ProductSold>(itemsSoldOrder));
        productsoldresults.Message = itemsSoldOrder.Quantity+" products  sale was a success";
      }

      return productsoldresults;
    }

    public InventorySummary GetInventorySummary()
    {
      var productlist = new List<ProductsPurchaseOrder>();

      foreach (var product in repository.GetAllProducts().Select(mapper.Map<ProductPurchase, ProductsPurchaseOrder>).ToList())
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

      var list = repository.GetAllProducts().Where(product => product.ProductTypeId.Equals(stockType.ProductTypeId)).Select(mapper.Map<ProductPurchase, ProductsPurchaseOrder>).ToList();

      inventory.InventoryProducts = list;

      inventory.AveragePrice = inventory.InventoryProducts.Select(price => price.UnitPrice).Sum() / inventory.InventoryProducts.Count();

      return inventory;
    }

    private ProductPurchase ProductExist(ProductsPurchaseOrder productpurchase)
    {
      var product = repository.GetAllProducts().FirstOrDefault(product =>
                        product.ProductName.Equals(productpurchase.ProductName)
                                && product.UnitPrice.Equals(productpurchase.UnitPrice)
                                       && product.ProductTypeId.Equals(productpurchase.ProductTypeId));

      if (product != null)
        return product;

      return null;
    }

    private bool CheckItemAvailability(ProductsSellOrder itemsSoldOrder)
    {
      var soldproduct = repository.GetAllSoldProducts().FirstOrDefault(product =>
                        product.ProductPurchaseId.Equals(itemsSoldOrder.ProductPurchaseId));

      var products_sold = repository.GetAllProducts();

      var purchasedproduct = repository.GetAllProducts().FirstOrDefault(product => product.ProductPurchaseId.Equals(itemsSoldOrder.ProductPurchaseId));

      if ((purchasedproduct.Quantity - itemsSoldOrder.Quantity) <= soldproduct.Quantity)
      {
        return false;
      }

      return true;
    }

    private ProductSold getSoldproduct(ProductsSellOrder itemsSoldOrder)
    {
      var product = repository.GetAllSoldProducts().FirstOrDefault(product =>
                         product.ProductPurchaseId.Equals(itemsSoldOrder.ProductPurchaseId));


      return product;
    }

    private decimal ComputerSellPrice(decimal UnitPrice)
    {
      return (decimal)(Convert.ToInt32(UnitPrice) * 0.2) + UnitPrice;
    }

  }
}
