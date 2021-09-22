using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BitCubeStore.DAL.Entities
{
  public class ProductPurchase
  {
    [Key]
    public int ProductPurchaseId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int ProductTypeId { get; set; }
    public virtual TypeProduct TypeProduct { get; set; }
  }
}
