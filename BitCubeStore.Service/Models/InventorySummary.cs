using System.Collections.Generic;

namespace BitCubeStore.Service.Models
{
    public class InventorySummary
    {
      public ICollection<ProductsPurchaseOrder> InventoryProducts { get; set; }
    }
}