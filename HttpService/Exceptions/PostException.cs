﻿using HttpService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpService.Exceptions
{
    public class PostException : Exception, IException
    {
        public string DeleteExceptionMessage { get; set; }
        public PostException(string message, Exception exception) : base(message, exception)
        {
        }

        public void SetDeleteExceptionMessage(string message)
        {
            this.DeleteExceptionMessage = message;
        }
    }
}
