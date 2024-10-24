﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Entities
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Result(bool isSuccess,string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
