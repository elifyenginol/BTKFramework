﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.CrossCuttingConcerns.Logging
{
    [Serializable]
    public class LogParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
    }
}
