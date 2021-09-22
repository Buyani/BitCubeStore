using BitCubeStore.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCubeStore.Service
{
  public interface IOnlineStore
  {
    void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder);
    ProductsSoldResults SellProductsFromInventory(ProductsSellOrder itemsSoldOrder);
    InventoryItemSummary GetInventoryItemSummary(ProductType stockType);
    InventorySummary InventorySummary();
  }
}
