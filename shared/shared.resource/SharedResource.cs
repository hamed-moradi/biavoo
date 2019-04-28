using System;
using System.Collections.Generic;
using System.Text;

namespace shared.resource {
    public class SharedResource {
        public static string Ok { get { return nameof(Ok); } }
        public static string BadRequest { get { return nameof(BadRequest); } }
        public static string InternalServerError { get { return nameof(InternalServerError); } }
        public static string AuthenticationFailed { get { return nameof(AuthenticationFailed); } }
        public static string InvalidSigninAttempt { get { return nameof(InvalidSigninAttempt); } }
        public static string TokenNotFound { get { return nameof(TokenNotFound); } }
        public static string DeviceIdNotFound { get { return nameof(DeviceIdNotFound); } }
        public static string UserIsNotActive { get { return nameof(UserIsNotActive); } }
        public static string PhoneIsNotVerified { get { return nameof(PhoneIsNotVerified); } }
        public static string ConnectionError { get { return nameof(ConnectionError); } }
        public static string UnexpectedError { get { return nameof(UnexpectedError); } }
        public static string NothingFound { get { return nameof(NothingFound); } }
        public static string DefectiveEntry { get { return nameof(DefectiveEntry); } }
        public static string RetrieveLimit { get { return nameof(RetrieveLimit); } }
        public static string DangerousRequest { get { return nameof(DangerousRequest); } }

    }
}
