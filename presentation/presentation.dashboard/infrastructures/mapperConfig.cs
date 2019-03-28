﻿using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace presentation.dashboard.infrastructures
{
    public class MapperConfig
    {
        public MapperConfiguration Init()
        {
            var mce = new MapperConfigurationExpression();
            var profiles = from asm in Assembly.GetExecutingAssembly().GetTypes()
                           where asm.Namespace == "presentation.dashboard.mapperProfiles"
                               && asm == typeof(Profile) && asm.IsClass
                           select asm;
            profiles.ToList().ForEach(e => mce.AddProfile(e));
            return new MapperConfiguration(mce);
        }
    }
}
