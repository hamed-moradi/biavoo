using AutoMapper;
using domain.repository.models;
using domain.repository.schemas;
using shared.model.bindingModels;
using shared.model.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace presentation.webApi.helpers {
    public class MapperConfig {
        public MapperConfiguration Init() {
            return new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
            //return new MapperConfiguration(config => config.AddProfiles("presentation.webApi.helpers")).CreateMapper();
            //var mce = new MapperConfigurationExpression();
            //var profiles = from asm in Assembly.GetExecutingAssembly().GetTypes()
            //               where asm.Namespace == "presentation.webApi.helpers"
            //                   && asm == typeof(Profile) && asm.IsClass
            //               select asm;
            //profiles.ToList().ForEach(e => mce.AddProfile(e));
            //return new MapperConfiguration(mce);
        }
    }

    public class MappingProfile: Profile {
        public MappingProfile() {
            // General
            CreateMap<GetById_BindingModel, GetById_Schema>();

            // Customer
            CreateMap<Customer_GetById_Model, Customer_GetById_ViewModel>();
            CreateMap<Customer_GetById_BindingModel, Customer_GetPaging_Schema>();

            // User
            CreateMap<User_SignIn_BindingModel, User_SignIn_Schema>();
            CreateMap<User_SignUp_Model, User_SignUp_ViewModel>();
            CreateMap<UserProperty_Model, UserProperty_ViewModel>();
            CreateMap<User_TwoFactorAuthentication_BindingModel, User_EnableTwoFactorAuthentication_Schema>();
            CreateMap<User_TwoFactorAuthentication_BindingModel, User_DisableTwoFactorAuthentication_Schema>();
            CreateMap<User_Verify_BindingModel, User_SetVerificationCode_Schema>();
            CreateMap<User_Verify_BindingModel, User_Verify_Schema>();

            // SendMessageQueue
            CreateMap<SendMessageQueue_GetPaging_BindingModel, SendMessageQueue_GetPaging_Schema>();
        }
    }
}
