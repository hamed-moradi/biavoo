using AutoMapper;
using domain.entity.models;
using domain.entity.schemas;
using presentation.webApi.models.bindingModels;
using presentation.webApi.models.viewModels;
using domain.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.mapperProfiles {
    public class UserProfile: Profile {
        public UserProfile() {
            CreateMap<UserModel, UserGetViewModel>();
            CreateMap<UserGetBindingModel, UserGetPagingSchema>();
        }
    }
}
