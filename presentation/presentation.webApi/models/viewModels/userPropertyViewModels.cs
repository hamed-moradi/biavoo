﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.viewModels {
    public class UserProperty_ViewModel: IBaseViewModel {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public int? Priority { get; set; }
        public long? StartedAt { get; set; }
        public long? EndedAt { get; set; }
    }
}
