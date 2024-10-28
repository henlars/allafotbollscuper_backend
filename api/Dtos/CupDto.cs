using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CupDto
    {
        public int Id { get; set; }
        public string Month { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Club { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string CategoriesSummary { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
    }
}