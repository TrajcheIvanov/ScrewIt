using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories
{
    public class ServicesRepository : BaseRepository<Service>, IServicesRepository
    {
        public ServicesRepository(ScrewItDbContext context) : base(context)
        {

        }
    }
}
