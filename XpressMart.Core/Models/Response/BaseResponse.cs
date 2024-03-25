using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart.Core.Models.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T Data { get; set; }

        public BaseResponse()
        {
            Errors = new List<string>();
        }

        public BaseResponse(T data, bool success = true, string message = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = new List<string>();
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
            Errors = new List<string>();
        }

        public BaseResponse(List<string> errors, bool success)
        {
            Success = success;
            Errors = errors;
        }
    }
}
