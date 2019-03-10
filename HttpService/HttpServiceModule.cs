using System;
using System.Collections.Generic;
using System.Text;

namespace HttpService
{
    public static class HttpServiceModule
    {
        public static readonly Lazy<HttpService.Implementation.HttpService> HTTPSERVICE = new Lazy<HttpService.Implementation.HttpService>();
    }
}
