using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class AdditionalServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DailyPrice { get; set; }
        public int Count { get; set; }
    }
}
