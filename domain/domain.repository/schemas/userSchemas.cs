﻿using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_user_signUp]")]
    public class UserSignUpSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @Name { get; set; }
        [InputParameter]
        public string @Family { get; set; }
        [InputParameter]
        public string @CellPhone { get; set; }
        [InputParameter]
        public string @Email { get; set; }

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