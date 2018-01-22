using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;

namespace Axxes.SpaceXLaunchDates.Helpers
{
    public class AxxesRestClient : RestClient
    {
        public AxxesRestClient(string baseUrl)
            : base(baseUrl)
        {
        }

        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            var response = Execute(request);

            // We provide our own custom deserialization so we can use the newtonsoft one
            // which is far better than the internal restsharp deserializer.
            return Deserialize<T>(request, response);
        }

        private static IRestResponse<T> Deserialize<T>(IRestRequest request, IRestResponse raw)
        {
            request.OnBeforeDeserialization(raw);

            var restResponse = (IRestResponse<T>) new RestResponse<T>();

            try
            {
                restResponse = raw.ToAsyncResponse<T>();
                restResponse.Request = request;

                if (restResponse.ErrorException == null)
                {
                    restResponse.Data = JsonConvert.DeserializeObject<T>(restResponse.Content);
                }
            }
            catch (Exception ex)
            {
                restResponse.ResponseStatus = ResponseStatus.Error;
                restResponse.ErrorMessage = ex.Message;
                restResponse.ErrorException = ex;
            }

            return restResponse;
        }
    }
}