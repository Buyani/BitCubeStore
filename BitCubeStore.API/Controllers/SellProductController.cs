﻿using BitCubeStore.Service;
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
  public class SellProductController : ControllerBase
  {
    private readonly IOnlineStore service;
    public SellProductController(IOnlineStore service)
    {
      this.service = service;
    }
    // GET: api/<SellProductController>
    [HttpGet]
    public InventorySummary Get()
    {
      return service.GetInventorySummary();
    }
    // POST api/<SellProductController>
    [HttpPost]
    public ProductsSoldResults Post([FromBody] ProductsSellOrder sellorder)
    {
      return service.SellProductsFromInventory(sellorder);
    }
  }
}
