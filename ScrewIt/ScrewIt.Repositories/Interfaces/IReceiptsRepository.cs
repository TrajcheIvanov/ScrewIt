using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories.Interfaces
{
    public interface IReceiptsRepository : IBaseRepository<Receipt>
    {
        Receipt GetByOrderId(int id);
    }
}
