﻿using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_user_signUp]")]
    public class UserSignUpSchema: IBaseSchema {
        #region User
        [InputParameter]
        public string @Name { get; set; }
        [InputParameter]
        public string @Family { get; set; }
        [InputParameter]
        public string @Nickname { get; set; }
        #endregion

        #region UserProperty
        [InputParameter]
        public string @CellPhone { get; set; }
        [InputParameter]
        public string @Email { get; set; }
        [InputParameter]
        public int @ActivitionCode { get; set; }
        #endregion

        #region Session
        [InputParameter]
        public string @TimeZone { get; set; }
        [InputParameter]
        public string @Language { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @IP { get; set; }
        [InputParameter]
        public string @OS { get; set; }
        [InputParameter]
        public string @Version { get; set; }
        [InputParameter]
        public string @DeviceName { get; set; }
        [InputParameter]
        public string @Browser { get; set; }
        #endregion

        [ReturnParameter]
        public int StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_sendActivationCode]")]
    public class UserSendActivationCodeSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @CellPhone { get; set; }

        [ReturnParameter]
        public int StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_getById]")]
    public class UserGetByIdSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @Id { get; set; }

        [ReturnParameter]
        public int StatusCode { get; set; }
    }
}