using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/cup")]
    [ApiController]

    public class CupController(ApplicationDBContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var cups = context.Cups.ToList();
            return Ok(cups);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var cup = context.Cups.Find(id);
            if (cup == null)
            {
                return NotFound();
            }
            return Ok(cup);
        }
    }

}