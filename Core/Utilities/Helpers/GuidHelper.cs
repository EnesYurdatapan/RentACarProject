﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
  public  class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
