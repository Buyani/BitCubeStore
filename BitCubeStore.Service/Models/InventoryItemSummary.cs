namespace BitCube.Service.Models
{
  public class InventoryItemSummary
  {
    public ProductType productType { get; set; }
    public decimal AveragePrice { get; set; }
    public int Quantity { get; set; }
  }
}