using ScrewIt.Models;
using ScrewIt.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.Interfaces
{
    public interface IReceiptItemsService
    {
        AddReceiptItemResponse Create(ReceiptItem receiptItem);
    }
}
