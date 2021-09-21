namespace BitCube.Service.Models
{
  public class ProductsPurchaseOrder
  {
    public int ProductPurchaseOrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }

  }
}