using System;

namespace BitCubeStore.Service.Models
{
    public class ProductsSellOrder
    {
    public int Quantity { get; set; }
    public int ProductPurchaseId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SellPrice { get; set; }

  }
}