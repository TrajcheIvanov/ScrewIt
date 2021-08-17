using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories
{
    public class ReceiptsRepository : BaseRepository<Receipt>, IReceiptsRepository
    {
        public ReceiptsRepository(ScrewItDbContext context) : base(context)
        {

        }
    }
}
