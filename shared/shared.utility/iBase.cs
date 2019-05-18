
namespace shared.utility {
    public interface IBase_Collection { }
    public interface IBase_Model { }
    public class Paging_Model: IBase_Model {
        public long TotalCount { get; set; }
    }
    public interface IBase_Schema { }
    public class Header_Schema: IBase_Schema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
    }
    public class FullHeader_Schema: Header_Schema { }
    public class Paging_Schema: Header_Schema {
        [InputParameter]
        public string @OrderBy { get; set; }
        [InputParameter]
        public string @Order { get; set; }
        [InputParameter]
        public int? @Skip { get; set; }
        [InputParameter]
        public int? @Take { get; set; }
    }
}
