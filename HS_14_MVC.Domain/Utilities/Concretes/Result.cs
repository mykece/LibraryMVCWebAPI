﻿using HS_14_MVC.Domain.Utilities.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Utilities.Concretes
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }

        public string Messages { get; }

        public Result()
        {
            IsSuccess = false;
            Messages = string.Empty;
        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Result(bool isSuccess, string messages) : this(isSuccess)
        {
            Messages = messages;
        }

    }
}
