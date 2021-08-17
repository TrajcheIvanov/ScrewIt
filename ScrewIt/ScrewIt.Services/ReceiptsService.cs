using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class ReceiptsService : IReceiptsService
    {

        private readonly IReceiptsRepository _receiptsRepository;

        public ReceiptsService(IReceiptsRepository receiptsRepository)
        {
            _receiptsRepository = receiptsRepository;
        }
    } 
}
