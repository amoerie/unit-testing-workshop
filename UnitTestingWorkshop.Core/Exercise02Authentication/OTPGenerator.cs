﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWorkshop.Core.Exercise02SMS
{
    public interface ITwoFactorCodeGenerator
    {
        string Generate();
    }
}