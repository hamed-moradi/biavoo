using AutoMapper;
using domain.repository.entities;
using presentation.dashboard.models;
using shared.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.dashboard.mapperProfiles {
    public class UserProfile: Profile {
        public UserProfile() {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
