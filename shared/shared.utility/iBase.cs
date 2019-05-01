
namespace shared.utility {
    public interface IBaseModel { }
    public interface IBaseSchema { }
    public class HeaderSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
    }
    public class FullHeaderSchema: HeaderSchema { }
    public class PagingSchema: IBaseSchema {
        [InputParameter]
        public string @OrderBy { get; set; }
        [InputParameter]
        public string @Order { get; set; }
        [InputParameter]
        public int? @Skip { get; set; }
        [InputParameter]
        public int? @Take { get; set; }
        [HelperParameter]
        public int RowsCount { get; set; }
    }
}
