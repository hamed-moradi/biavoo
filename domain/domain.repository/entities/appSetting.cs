
namespace domain.repository.entities
{

    public partial class AppSetting
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int? Priority { get; set; }
    }
    public partial class AppSetting
    {
        public long RowsCount { get; set; }
    }

}
