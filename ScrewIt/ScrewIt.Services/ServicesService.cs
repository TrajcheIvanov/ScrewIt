using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServicesRepository _servicesRepository;
        public ServicesService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
    }
}
