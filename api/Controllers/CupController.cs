using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/cup")]
    [ApiController]

    public class CupController(ApplicationDBContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cups = await context.Cups.ToListAsync();
            var stockDto = cups.Select(c => c.ToCupDto());
            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cup = await context.Cups.FindAsync(id);
            if (cup == null)
            {
                return NotFound();
            }
            return Ok(cup.ToCupDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCupRequestDto cupDto)
        {
            var cupModel = cupDto.ToCupFromCreateDto();
            await context.Cups.AddAsync(cupModel);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = cupModel.Id, }, cupModel.ToCupDto());

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCupRequestDto updateDto)
        {
            var cupModel = await context.Cups.FirstOrDefaultAsync(x => x.Id == id);
            if (cupModel == null)
            {
                return NotFound();
            }
            cupModel.Month = updateDto.Month;
            cupModel.Name = updateDto.Name;
            cupModel.Club = updateDto.Club;
            cupModel.Date = updateDto.Date;
            cupModel.Categories = updateDto.Categories;
            cupModel.CategoriesSummary = updateDto.CategoriesSummary;
            cupModel.Link = updateDto.Link;
            cupModel.Year = updateDto.Year;
            cupModel.County = updateDto.County;

            await context.SaveChangesAsync();
            return Ok(cupModel.ToCupDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cupModel = await context.Cups.FirstOrDefaultAsync(x => x.Id == id);

            if (cupModel == null)
            {
                return NotFound();
            }
            context.Cups.Remove(cupModel);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}




