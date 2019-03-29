using domain.application._app;
using domain.repository.schemas;
using domain.application;
using Newtonsoft.Json;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class ExceptionService: IExceptionService {
        #region Constructor
        private readonly IStoreProcedure<IBaseModel, ExceptionInsertSchema> _matchPredict;
        public ExceptionService(IStoreProcedure<IBaseModel, ExceptionInsertSchema> matchPredict) {
            _matchPredict = matchPredict;
        }
        #endregion

        public async Task InsertAsync(Exception model, string url, string ip) {
            var schema = new ExceptionInsertSchema {
                URL = url,
                Data = JsonConvert.SerializeObject(model.Data.Keys),
                IP = ip,
                Message = model.Message,
                Source = model.Source,
                StackTrace = model.StackTrace,
                TargetSite = model.TargetSite.ToString()
            };
            await _matchPredict.ExecuteReturnLessAsync(schema);
        }
    }
}
