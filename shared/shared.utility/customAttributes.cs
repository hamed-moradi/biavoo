using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace shared.utility {
    public class Schema: Attribute {
        public string Name { get; set; }
        public Schema(string name = null) {
            Name = name;
        }
    }
    public class InputParameter: Attribute {
        public string Name { get; set; }
        public InputParameter(string name = null) {
            Name = name;
        }
    }
    public class OutputParameter: Attribute {
        public string Name { get; set; }
        public OutputParameter(string name = null) {
            Name = name;
        }
    }
    public class ErrorAttribute: Attribute {
        public string Message { get; set; }

        public ErrorAttribute(string message) {
            Message = message;
        }
    }
    public class HelperParameter: Attribute { }
    //public class SearchAttribute: Attribute {//, IMetadataAware {
    //    public SearchAttribute(GeneralEnums.SearchFieldType type = GeneralEnums.SearchFieldType.String) {
    //        Type = type;
    //    }
    //    public GeneralEnums.SearchFieldType Type { get; }
    //    public void OnMetadataCreated(ModelMetadata metadata) {
    //        metadata.AdditionalValues["Type"] = Type;
    //    }
    //}
}
