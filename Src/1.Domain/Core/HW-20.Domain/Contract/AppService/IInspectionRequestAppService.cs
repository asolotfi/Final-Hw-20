﻿using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;

namespace HW_20.Domain.Contract.AppService
{
    public interface IInspectionRequestAppService
    {
        bool AddInspectionRequest(string PhoneNumber, string codeMeli, int Number2, StringNumberEnum StringNumber, int Number3, Car Car, CarModel CarModel);
    }
}
