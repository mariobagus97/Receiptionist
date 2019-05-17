using Intersoft.Crosslight;
using Intersoft.Crosslight.RestClient;
using Receiptionist.Core.Models;
using Receiptionist.Core.RestRequestModel;
using System.Threading.Tasks;

namespace Receiptionist.Core.ModelServices.WebApi
{
    public class SskRestRepository
    {
        #region Fields
        private IRestClient _restClient;
        private string baseUrl = "http://192.168.1.56:58360";
        //private string baseUrl = "http://192.168.8.100:58360";
        //private string baseUrl = "http://webreciptionistnew-test.ap-southeast-1.elasticbeanstalk.com";

        #endregion

        #region Properties
        public IRestClient RestClient
        {
            get
            {
                if (_restClient == null)
                    _restClient = this.InitializeRestClient();

                return _restClient;
            }
        }

        public IRestClient InitializeRestClient()
        {
            return new RestClient()
            {
                BaseUrl = baseUrl
            };
        }
        #endregion

        #region methods

        public virtual async Task<Employee> GetEmployeeAsync(string name)
        {
            IRestRequest postRequest = new RestRequest("data/Search/SearchingEmployee", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(name);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            Employee data = SimpleJson.DeserializeObject<Employee>(postResponse.Content);

            return data;
        }

        public virtual async Task<Visitor> GetVisitorAsync(string phoneNumber)
        {
            IRestRequest postRequest = new RestRequest("data/Search/SearchingVisitor", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(phoneNumber);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            Visitor data = SimpleJson.DeserializeObject<Visitor>(postResponse.Content);

            return data;
        }

        public virtual async Task<Meeting> GetMeetingAsync(GetMeetingRequestParameter filter)
        {
            IRestRequest postRequest = new RestRequest("data/Search/SearchingMeeting", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(filter);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            Meeting data = SimpleJson.DeserializeObject<Meeting>(postResponse.Content);
            return data;
        }

        public virtual async Task<Meeting> SaveMeetingAsync(Meeting entity)
        {
            IRestRequest postRequest = new RestRequest("data/SelfKios/NewMeeting", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);

            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            Meeting data = SimpleJson.DeserializeObject<Meeting>(postResponse.Content);

            return data;

            //try
            //{
            //    IRestResponse<Meeting> postResponse = await client.ExecuteAsync<Meeting>(postRequest);

            //    if (postResponse.Data == null)
            //        throw new Exception(postResponse.Content);

            //    return postResponse.Data;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public virtual async Task<Meeting> NotifyEmailAsync(Meeting entity)
        {
            IRestRequest postRequest = new RestRequest("data/SelfKios/NotifyEmailEmployee", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            Meeting data = SimpleJson.DeserializeObject<Meeting>(postResponse.Content);

            return data;
        }

        #endregion
    }
}
