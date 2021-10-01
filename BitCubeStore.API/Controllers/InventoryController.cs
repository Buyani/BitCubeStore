using BitCubeStore.Service;
using BitCubeStore.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCubeStore.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : ControllerBase
  {

    private readonly IOnlineStore service;
    public InventoryController(IOnlineStore service)
    {
      this.service = service;
    }
    [HttpPost]
    public InventoryItemSummary Get(ProductType stockType)
    {
      return service.GetInventoryItemSummary(stockType);
    }   
  }
}
