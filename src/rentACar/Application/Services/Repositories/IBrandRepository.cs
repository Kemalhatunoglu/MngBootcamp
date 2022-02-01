using Core.Persistence.Repositories;
using Domain.Entities.Concete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories //Bu katman dış katmanlardan hizmet almayı düşündüğümüz kontratların temelidir.
{
    public interface IBrandRepository : IAsyncRepository<Brand>
    {

    }
}
