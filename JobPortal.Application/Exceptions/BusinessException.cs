using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Exceptions
{
    public class BusinessException : Exception
    {
        public string ErrorCode { get; }

        public BusinessException(string message, string errorCode = "This is Business Error")
            : base(message)
        {
            ErrorCode = errorCode;
        }

    }
}
