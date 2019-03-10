using HttpService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpService.Exceptions
{
    public class DeleteException : Exception, IException
    {
        public string DeleteExceptionMessage { get; set; }
        public DeleteException(string message, Exception exception) : base (message, exception)
        {
        }

        public void SetDeleteExceptionMessage(string message)
        {
            this.DeleteExceptionMessage = message;
        }
    }
}
