using AutoMapper;
using domain.repository.models;
using domain.repository.schemas;
using presentation.webApi.models.bindingModels;
using presentation.webApi.models.viewModels;
using shared.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.mapperProfiles {
    public class UserProfile: Profile {
        public UserProfile() {
            CreateMap<UserGetByIdModel, UserGetViewModel>();
            CreateMap<UserGetBindingModel, UserGetPagingSchema>();
        }
    }
}
