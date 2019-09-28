using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {
    [Schema("[dbo].[api_user_signIn")]
    public class User_SignIn_Schema: Header_Schema {
        [InputParameter]
        public string @VerificationCode { get; set; }
        [InputParameter]
        public string @Password { get; set; }

        [OutputParameter]
        public new string @Token { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
    [Schema("[dbo].[api_user_signUp]")]
    public class User_SignUp_Schema: IBase_Schema {
        #region User
        [InputParameter]
        public string @Name { get; set; }
        [InputParameter]
        public string @Family { get; set; }
        [InputParameter]
        public string @Nickname { get; set; }
        #endregion

        #region Customer
        public string @NationalCode { get; set; }
        public DateTime? @BirthDate { get; set; }
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

        [OutputParameter]
        public string Token { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
    [Schema("[dbo].[api_user_setVerificationCode]")]
    public class User_SetVerificationCode_Schema: IBase_Schema {
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @CellPhone { get; set; }
        [InputParameter]
        public string @Email { get; set; }
        [InputParameter]
        public int VerificationCode { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_verify]")]
    public class User_Verify_Schema: IBase_Schema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @CellPhone { get; set; }
        [InputParameter]
        public string @Email { get; set; }
        [InputParameter]
        public int VerificationCode { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_enableTwoFactorAuthentication")]
    public class User_EnableTwoFactorAuthentication_Schema: Header_Schema {
        [InputParameter]
        public int VerificationCode { get; set; }
        [InputParameter]
        public string Password { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
    [Schema("[dbo].[api_user_disableTwoFactorAuthentication")]
    public class User_DisableTwoFactorAuthentication_Schema: Header_Schema {
        [InputParameter]
        public string Password { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_updateProfile]")]
    public class User_UpdateProfile_Schema: Header_Schema {
        [InputParameter]
        public string @Nickname { get; set; }
        [InputParameter]
        public string @Avatar { get; set; }
        [InputParameter]
        public DateTime? @BirthDate { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_updatePrivacy]")]
    public class User_UpdatePrivacy_Schema: Header_Schema {
        [InputParameter]
        public string @AppearingInSearch { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_disableMe]")]
    public class User_DisableMe_Schema: Header_Schema {
        [InputParameter]
        public string @Description { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
}