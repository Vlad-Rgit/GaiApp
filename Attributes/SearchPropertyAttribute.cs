﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SearchPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public SearchPropertyAttribute(string propertyName)
            => PropertyName = propertyName;
    }
}
