﻿using HS_14_MVC.Domain.Utilities.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Utilities.Concretes
{
    public class DataResult<T> : Result, IDataResult<T> where T : class
    {
        public T? Data { get; }

        public DataResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }
        public DataResult(T data, bool isSuccess, string message) : base(isSuccess, message)
        {
            Data = data;
        }
    }
}
