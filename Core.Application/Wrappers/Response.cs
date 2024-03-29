﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string message = null, bool IsSucceeded = false, List<FluentValidation.Results.ValidationFailure> validationErrors = null)
        {
            Succeeded = IsSucceeded;
            Message = message;
            Data = data;
            ValidationErrors = validationErrors;
        }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public List<FluentValidation.Results.ValidationFailure> ValidationErrors { get; set; }
    }
}
