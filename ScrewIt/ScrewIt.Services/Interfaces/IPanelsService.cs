using ScrewIt.Models;
using ScrewIt.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.Interfaces
{
    public interface IPanelsService
    {
        StatusModel CreatePanel(Panel domainModel);
        List<Panel> GetAll();
        Panel GetById(int id);
        StatusModel Update(Panel domainModel);
        StatusModel Delete(int id);
    }
}
