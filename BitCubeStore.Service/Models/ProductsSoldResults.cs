namespace BitCubeStore.Service.Models
{
  public class ProductsSoldResults
  {
    public int Quantity { get; set; }
    public bool ProductSold { get; set; }
    public decimal SellingPrice { get; set; }
    public string ProductName { get; set; }
  }
}