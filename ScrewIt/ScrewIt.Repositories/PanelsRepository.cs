using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories
{
    public class PanelsRepository : BaseRepository<Panel>,IPanelsRepository
    {
        public PanelsRepository(ScrewItDbContext context) : base(context)
        {
        }
    }
}
