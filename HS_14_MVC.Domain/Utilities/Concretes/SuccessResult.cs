﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Utilities.Concretes
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true) { }
        public SuccessResult(string message) : base(true, message) { }


    }
}
