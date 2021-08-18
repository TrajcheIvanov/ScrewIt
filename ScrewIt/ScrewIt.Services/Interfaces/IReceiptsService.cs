using ScrewIt.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.Interfaces
{
    public interface IReceiptsService
    {
        List<String> GetProductOffer(string term);
        CheckProductResponse CheckIfProductIsValid(string product);
    }
}
