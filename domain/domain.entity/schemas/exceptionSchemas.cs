using domain.utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entity.schemas {
    [Schema("[dbo].[api_exception_insert]")]
    public class ExceptionInsertSchema: IBaseSchema {
        [InputParameter]
        public string @URL { get; set; }
        [InputParameter]
        public string @Data { get; set; }
        [InputParameter]
        public string @Message { get; set; }
        [InputParameter]
        public string @Source { get; set; }
        [InputParameter]
        public string @StackTrace { get; set; }
        [InputParameter]
        public string @TargetSite { get; set; }
        [InputParameter]
        public string @IP { get; set; }
    }
}
