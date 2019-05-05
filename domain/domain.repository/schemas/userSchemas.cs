using shared.utility;
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
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_sendVerificationCode]")]
    public class UserSendVerificationCodeSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @Number { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_getById]")]
    public class UserGetByIdSchema: HeaderSchema {
        [InputParameter]
        public int @Id { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_enableTwoFactorAuthentication")]
    public class EnableTwoFactorAuthenticationSchema: HeaderSchema {
        [InputParameter]
        public int VerificationCode { get; set; }
        [InputParameter]
        public string Password { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
    [Schema("[dbo].[api_user_disableTwoFactorAuthentication")]
    public class DisableTwoFactorAuthenticationSchema: HeaderSchema {
        [InputParameter]
        public string Password { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
}