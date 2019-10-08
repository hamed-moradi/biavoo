using RestSharp;
using asset.model.viewModels;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Serilog;

namespace presentation.executor {
    class Program {
        #region ctor
        private static readonly object syncLock = new object();
        #endregion  

        static void Main(string[] args) {
            lock(syncLock) {
                Log.Logger = new LoggerConfiguration().WriteTo.File("executor_log.txt").CreateLogger();

                var client = new RestClient(AppSettings.Url);
                var request = new RestRequest(AppSettings.Uri, Method.GET);

                request.AddParameter("typeId", AppSettings.TypeId);
                request.AddParameter("categoryId", AppSettings.CategoryId);
                request.AddParameter("cellPhone", AppSettings.CellPhone);
                request.AddParameter("eMail", AppSettings.EMail);
                request.AddParameter("gateway", AppSettings.Gateway);
                request.AddParameter("orderBy", AppSettings.OrderBy);
                request.AddParameter("order", AppSettings.Order);
                request.AddParameter("pageSize", AppSettings.PageSize);

                request.AddHeader("Token", AppSettings.SystemToken);
                request.AddHeader("DeviceId", AppSettings.SystemDeviceId);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                Task.Factory.StartNew(() => {
                    client.ExecuteAsync<Base_ViewModel>(request, rsp => {

                        stopwatch.Stop();
                        if(stopwatch.Elapsed > TimeSpan.FromSeconds(60)) {
                            Log.Warning($"Proccess took too long {stopwatch.Elapsed.Seconds}'s");
                        }

                        switch(rsp.Data.Status) {
                            case HttpStatusCode.OK:
                                break;
                            case HttpStatusCode.BadRequest:
                                break;
                            case HttpStatusCode.BadGateway:
                                break;
                            case HttpStatusCode.InternalServerError:
                                break;
                        }
                    });
                });
            }
        }
    }
}
