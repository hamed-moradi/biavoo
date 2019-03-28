using AutoMapper;
using domain.repository.models;
using domain.repository.schemas;
using presentation.dashboard.models.bindingModels;
using presentation.dashboard.models.viewModels;
using domain.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.dashboard.mapperProfiles {
    public class UserProfile: Profile {
        public UserProfile() {
            CreateMap<UserModel, UserGetViewModel>();
            CreateMap<UserGetBindingModel, UserGetPagingSchema>();
        }
    }
}
