﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApiService.Utils
{
    public static class Extends
    {
        public static string ToGetParameters(this Dictionary<string, string> pars)
        {
            if (pars == null || pars.Count == 0)
            {
                return "";
            }
            var paramString = "?" + string.Join("&", pars.Select(x => $"{x.Key}={x.Value}"));
            return paramString;
        }
    }
}
