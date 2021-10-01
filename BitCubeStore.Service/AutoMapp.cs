using AutoMapper;
using BitCubeStore.DAL.Entities;
using BitCubeStore.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCubeStore.Service
{
  public class AutoMapp:Profile
  {
    public AutoMapp()
    {

      CreateMap<ProductPurchase, ProductsPurchaseOrder>();
      CreateMap<ProductsPurchaseOrder, ProductPurchase>();

      CreateMap<ProductSold, ProductsSellOrder>();
      CreateMap<ProductsSellOrder, ProductSold>();

      CreateMap<ProductPurchase, InventorySummary>();

    }
  }
}
