using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_customer_signIn")]
    public class Customer_SignIn_Schema: Header_Schema {
        [InputParameter]
        public string @VerificationCode { get; set; }
        [InputParameter]
        public string @Password { get; set; }

        [OutputParameter]
        public new string @Token { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
    [Schema("[dbo].[api_customer_signUp]")]
    public class Customer_SignUp_Schema: IBase_Schema {
        #region User
        [InputParameter]
        public string @Name { get; set; }
        [InputParameter]
        public string @Family { get; set; }
        [InputParameter]
        public string @Nickname { get; set; }
        #endregion

        #region Customer
        public string NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
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
    [Schema("[dbo].[api_customer_getById]")]
    public class Customer_GetById_Schema: IBase_Schema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @Id { get; set; }

        [ReturnParameter]
        public byte StatusCode { get; set; }
    }

    [Schema("[dbo].[api_customer_getPaging]")]
    public class Customer_GetPaging_Schema: Paging_Schema {
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public DateTime? @FromDate { get; set; }
        [InputParameter]
        public DateTime? @ToDate { get; set; }

        [ReturnParameter]
        public byte StatusCode { get; set; }
    }
}