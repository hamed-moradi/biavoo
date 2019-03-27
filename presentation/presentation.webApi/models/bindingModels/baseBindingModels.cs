using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace presentation.webApi.models.bindingModels {
    public interface IBaseBindingModel { }
    public class HeaderBindingModel: IBaseBindingModel {
        public Guid ApplicationOwnerKey { get; set; }
        public Guid DataOwnerCenterKey { get; set; }
        public Guid DataOwnerKey { get; set; }
    }
    public class FullHeaderBindingModel: HeaderBindingModel {
        public string OS { get; set; }
        public string Version { get; set; }
        public string DeviceName { get; set; }
        public string Browser { get; set; }
    }
    public class BindingModel: HeaderBindingModel {
        public string OrderBy { get; set; } = "Id";
        public string Order { get; set; } = "DESC";
        public int? PageIndex { get; set; } = 0;
        public int? PageSize { get; set; } = 10;
        public int Skip { get { return (PageIndex * PageSize).Value; } }
        public int Take { get { return PageSize.Value; } }
        public int TotalPages(int rowsCount) {
            return (int)Math.Ceiling((decimal)rowsCount / PageSize.Value);
        }
    }
    public class CBaseBindingModel:IBaseBindingModel {
        public virtual int ID { get; set; }
        public virtual Guid UniqueId { get; set; }
        public virtual Guid ApplicationOwnerId { get; set; }
        public virtual Guid DataOwnerId { get; set; }
        public virtual Guid DataOwnerCenterId { get; set; }
        public virtual bool IsRemoved { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime LastUpdate { get; set; }
        public virtual Guid DataGeneratedOwnerCenterId { get; set; }
        public virtual long ConcurrencyCheckField { get; set; }
    }
    //[ProtoContract]
    //[ProtoInclude(9, typeof(ProductViewModel))]
    //[ProtoInclude(10, typeof(ProductTypeViewModel))]
    //[ProtoInclude(11, typeof(SupplierViewModel))]
    //[ProtoInclude(12, typeof(CharValueViewModel))]
    //[ProtoInclude(13, typeof(ProductPictureViewModel))]
    public class BaseBindingModel: CBaseBindingModel {
        //[ProtoMember(1)]
        public override int ID { get; set; }
        //[ProtoMember(2)]
        public override Guid UniqueId { get; set; }
        //[ProtoMember(3)]
        public override Guid ApplicationOwnerId { get; set; }
        //[ProtoMember(4)]
        public override Guid DataOwnerId { get; set; }
        //[ProtoMember(5)]
        public override Guid DataOwnerCenterId { get; set; }
        //[ProtoMember(6)]
        public override bool IsRemoved { get; set; }
        //[ProtoMember(7)]
        public override DateTime CreatedDate { get; set; }
        //[ProtoMember(8)]
        public override DateTime LastUpdate { get; set; }
    }
}
