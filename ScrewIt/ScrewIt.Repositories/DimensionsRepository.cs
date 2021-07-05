using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories
{
    public class DimensionsRepository : BaseRepository<Dimension> , IDimensionsRepository
    {
        public DimensionsRepository(ScrewItDbContext context) : base (context)
        {

        }
    }
}
