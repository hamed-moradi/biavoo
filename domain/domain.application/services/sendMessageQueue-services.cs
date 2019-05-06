using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class SendMessageQueue_Service: ISendMessageQueue_Service {
        #region Constructor
        private readonly IStoreProcedure<SendMessageQueue_Model, SendMessageQueue_GetPaging_Schema> _sendMessageQueueGet;
        public SendMessageQueue_Service(IStoreProcedure<SendMessageQueue_Model, SendMessageQueue_GetPaging_Schema> sendMessageQueueGet) {
            _sendMessageQueueGet = sendMessageQueueGet;
        }
        #endregion

        public async Task<List<SendMessageQueue_Model>> GetPagingAsync(SendMessageQueue_GetPaging_Schema model) {
            var result = await _sendMessageQueueGet.ExecuteAsync(model);
            return result.ToList();
        }
    }
}
