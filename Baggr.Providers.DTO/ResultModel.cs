using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO
{
    public enum StatusMessage
    {
        Ok,
        BadRequest,
        Conflict,
        Forbidden,
        NotFound,
        ServerError,
        BadGateway,
        GatewayTimeout
    }
    public class ResultModel<T> where T : class
    {
        public bool IsSuccess { get; set; }

        public StatusMessage StatusMessage { get; set; }

        public T Result { get; set; }

        public ResultModel(bool isSuccess, StatusMessage statusMessage)
        {
            IsSuccess = isSuccess;
            StatusMessage = statusMessage;
        }

        public ResultModel(bool isSuccess, StatusMessage statusMessage, T result)
        {
            IsSuccess = isSuccess;
            StatusMessage = statusMessage;
            Result = result;
        }
    }
}
