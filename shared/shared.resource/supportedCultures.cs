﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace shared.resource {
    public class SupportedCultures {
        public static CultureInfo[] List {
            get {
                return new[] {
                    new CultureInfo("en"),
                    new CultureInfo("fa")
                };
            }
        }
    }
}
