using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class CupMappers
    {
        public static CupDto ToCupDto(this Cup cupModel)
        {
            return new CupDto
            {
                Id = cupModel.Id,
                Name = cupModel.Name,
                Month = cupModel.Month,
                Date = cupModel.Date,
                Club = cupModel.Club,
                Categories = cupModel.Categories,
                CategoriesSummary = cupModel.CategoriesSummary,
                Link = cupModel.Link,
                Year = cupModel.Year,
                County = cupModel.County,
            };
        }
        public static Cup ToCupFromCreateDto(this CreateCupRequestDto cupDto)
        {
            return new Cup
            {
                Name = cupDto.Name,
                Month = cupDto.Month,
                Date = cupDto.Date,
                Club = cupDto.Club,
                Categories = cupDto.Categories,
                CategoriesSummary = cupDto.CategoriesSummary,
                Link = cupDto.Link,
                Year = cupDto.Year,
                County = cupDto.County,
            };
        }
    }
}
