﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace asset.resource {
    public class SupportedLanguages {
        public static CultureInfo[] List {
            get {
                return new[] {
                    new CultureInfo("en-US"),
                    new CultureInfo("fa")
                };
            }
        }
    }
}
