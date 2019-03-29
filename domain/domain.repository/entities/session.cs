using System;

namespace domain.repository.entities {
    public partial class Session {
        public int? Id { get; set; }
        public string Token { get; set; }
        public string IP { get; set; }
        public int? UserId { get; set; }
        public int? DeviceId { get; set; }
        public string OS { get; set; }
        public string Version { get; set; }
        public string DeviceName { get; set; }
        public string Browser { get; set; }
        public byte? Status { get; set; }
        public string FcmId { get; set; }
    }

    public partial class Session {
        public long RowsCount { get; set; }
    }
}