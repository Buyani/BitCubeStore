using BitCubeStore.Service;
using BitCubeStore.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BitCubeStore.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    private readonly IOnlineStore service;
    public StoreController(IOnlineStore service)
    {
      this.service = service;
    }

    // GET: api/<StoreController>
    [HttpGet]
    public InventorySummary Get()
    {
      return service.GetInventorySummary();
    }
    [HttpGet("{ProductTypeId}")]


    // POST api/<StoreController>
    [HttpPost]
    [Route("PostProduct")]
    public void Post([FromBody] ProductsPurchaseOrder product)
    {
      service.AddProductsToInventory(product);
    }
  }
}
