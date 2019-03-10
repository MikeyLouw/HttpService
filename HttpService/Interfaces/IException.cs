using System;
using System.Collections.Generic;
using System.Text;

namespace HttpService.Interfaces
{
    public interface IException
    {
        string DeleteExceptionMessage { get; set; }
        void SetDeleteExceptionMessage(string message);
    }
}
