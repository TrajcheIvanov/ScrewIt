using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class DimensionsService : IDimensionsService
    {
        private readonly IDimensionsRepository _dimensionsRepository;

        public DimensionsService(IDimensionsRepository dimensionsRepository)
        {
            _dimensionsRepository = dimensionsRepository;
        }
    }
}
