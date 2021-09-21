using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BitCubeStore.DAL.Entities
{
  public class ProductSold
  {
    [Key]
    public int Id { get; set; }
    public int ProductPurchaseId { get; set; }
    public int Quantity { get; set; }
    public decimal SellPrice { get; set; }
    public decimal UnitPrice { get; set; }
    public virtual ProductPurchase ProductPurchase { get; set; }
  }
}
