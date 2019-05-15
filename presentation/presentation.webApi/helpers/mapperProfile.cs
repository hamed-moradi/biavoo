using AutoMapper;
using domain.repository.models;
using domain.repository.schemas;
using shared.model.bindingModels;
using shared.model.viewModels;
using shared.utility._app;
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
            CreateMap<FullHeader_BindingModel, Void_Schema>();

            // Customer
            CreateMap<Customer_Model, Customer_ViewModel>();
            CreateMap<Customer_GetById_Model, Customer_GetById_ViewModel>();
            CreateMap<Customer_GetById_BindingModel, Customer_GetPaging_Schema>();

            // User
            CreateMap<User_SignIn_BindingModel, User_SignIn_Schema>();
            CreateMap<User_Model, User_SignUp_ViewModel>();
            CreateMap<UserProperty_Model, UserProperty_ViewModel>();
            CreateMap<User_TwoFactorAuthentication_BindingModel, User_EnableTwoFactorAuthentication_Schema>();
            CreateMap<User_TwoFactorAuthentication_BindingModel, User_DisableTwoFactorAuthentication_Schema>();
            CreateMap<User_Verify_BindingModel, User_SetVerificationCode_Schema>();
            CreateMap<User_Verify_BindingModel, User_Verify_Schema>();
            CreateMap<User_Update_BindingModel, User_Update_Schema>()
                .ForMember(d => d.BirthDate, s => s.MapFrom(f => f.BirthDate.ToDateTime(null)));
            CreateMap<User_DisableMe_BindingModel, User_DisableMe_Schema>();

            // SendMessageQueue
            CreateMap<SendMessageQueue_GetPaging_BindingModel, SendMessageQueue_GetPaging_Schema>();

            // Business
            CreateMap<Business_Get_BindingModel, Business_Get_Schema>();
            CreateMap<Business_New_BindingModel, Business_New_Schema>();
            CreateMap<Business_Edit_BindingModel, Business_Edit_Schema>();
            CreateMap<Business_Model, Business_ViewModel>();
        }
    }
}
