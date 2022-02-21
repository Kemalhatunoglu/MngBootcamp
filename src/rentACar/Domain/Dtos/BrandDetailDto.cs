using Domain.Entities.Concete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class BrandDetailDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public List<ModelDetailDto> Models { get; set; }
    }
}
