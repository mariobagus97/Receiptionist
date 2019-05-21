using Intersoft.Crosslight;
using Intersoft.Crosslight.RestClient;
using Receiptionist.Core.Models;
using System.Threading.Tasks;


namespace Receiptionist.Core.ModelServices
{
    public class RestRepositoryBase<T>  where T : class , new()
    {

        #region Fields
        private IRestClient _restClient;
        //private string baseUrl = "http://192.168.1.77:58360";
        private string baseUrl = "http://192.168.8.100:58360";
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

        public virtual async Task<T> GetEmployeeAsync(T entity)
        {
            IRestRequest postRequest = new RestRequest("data/Search/SearchingEmployee", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }

        public virtual async Task<T> GetVisitorAsync(T entity)
        {
            IRestRequest postRequest = new RestRequest("data/Search/SearchingVisitor", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }

        public virtual async Task<T> GetMeetingAsync(T entity)
        {
            IRestRequest postRequest = new RestRequest("data/Search/SearchingMeeting", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);
            
            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }
        
        public virtual async Task<T> InsertAsync(Meeting entity)
        {
            IRestRequest postRequest = new RestRequest("data/SelfKios/NewMeeting", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);

            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

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
        
        public virtual async Task<T> NotifyEmailAsync(T entity)
        {
            IRestRequest postRequest = new RestRequest("data/SelfKios/NotifyEmailEmployee", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await RestClient.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }
        
        #endregion
    }
}