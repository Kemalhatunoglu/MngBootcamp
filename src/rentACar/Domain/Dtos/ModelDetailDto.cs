using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ModelDetailDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public float DailyPrice { get; set; }
        public string ImageUrl { get; set; }

    }
}
