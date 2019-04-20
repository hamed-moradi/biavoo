using AutoMapper;
using AutoMapper.Configuration;
using domain.repository.models;
using domain.repository.schemas;
using presentation.webApi.models.bindingModels;
using presentation.webApi.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace presentation.webApi.helpers {
    public class MapperConfig {
        public MapperConfig() {
            new MapperConfiguration(config => config.AddProfiles("presentation.webApi.helpers")).CreateMapper();
        }
        //public MapperConfiguration Init() {
        //    var mce = new MapperConfigurationExpression();
        //    var profiles = from asm in Assembly.GetExecutingAssembly().GetTypes()
        //                   where asm.Namespace == "presentation.webApi.helpers"
        //                       && asm == typeof(Profile) && asm.IsClass
        //                   select asm;
        //    profiles.ToList().ForEach(e => mce.AddProfile(e));
        //    return new MapperConfiguration(mce);
        //}
    }

    public class MapperProfile: Profile {
        public MapperProfile() {
            CreateMap<CustomerGetByIdModel, CustomerGetByIdViewModel>();
            CreateMap<CustomerGetByIdBindingModel, CustomerGetPagingSchema>();

            CreateMap<UserModel, UserGetViewModel>();
            CreateMap<UserGetBindingModel, UserGetPagingSchema>();

            CreateMap<UserPropertyModel, UserPropertyViewModel>();
        }
    }
}
