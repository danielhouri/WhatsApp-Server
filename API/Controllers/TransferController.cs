#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API;
using API.Data;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _service;

        public TransferController(ITransferService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([Bind("from,to,content")] Transfer msg)
        {
            if(_service.AddMessage(msg.From, msg.To, msg.Content))
            {
                return Created(string.Format("/api/Contacts/{0}", msg.From), msg.From);
            }
            return BadRequest();
        }
    }
}
