using AutoMapper;
using domain.repository.entities;
using MD.PersianDateTime.Core;
using presentation.dashboard.models;
using shared.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.dashboard.helpers {
    public class UserProfile: Profile {
        public UserProfile() {
            CreateMap<Admin, AccountPrincipal>()
                .ForMember(d => d.LastLoggedin, s => s.MapFrom(f => new PersianDateTime(f.LastLoggedin).ToShortDateTimeString()));

            CreateMap<Admin, AdminViewModel>();
            CreateMap<AdminViewModel, Admin>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
