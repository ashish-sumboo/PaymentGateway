using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Dtos
{
    public class ErrorResponseDto
    {
        public string Code { get; }

        public string Message { get; }

        public ErrorResponseDto(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
