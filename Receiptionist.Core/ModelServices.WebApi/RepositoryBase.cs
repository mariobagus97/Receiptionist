using Intersoft.Crosslight;
using Intersoft.Crosslight.RestClient;
using System.Threading.Tasks;


namespace Receiptionist.Core.ModelServices
{
    public class RepositoryBase<T>  where T : class , new()
    {

        #region Fields

        //private string baseUrl = "http://192.168.1.56:58360";
        private string baseUrl = "http://192.168.8.102:58360";
        //private string baseUrl = "http://webreciptionistnew-test.ap-southeast-1.elasticbeanstalk.com";

        #endregion

        #region methods

        public virtual async Task<T> GetEmployeeAsync(T entity)
        {
            IRestClient client = new RestClient(baseUrl);

            IRestRequest postRequest = new RestRequest("data/Search/SearchingEmployee", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await client.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }

        public virtual async Task<T> GetVisitorAsync(T entity)
        {
            IRestClient client = new RestClient(baseUrl);

            IRestRequest postRequest = new RestRequest("data/Search/SearchingVisitor", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await client.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }

        public virtual async Task<T> GetMeetingAsync(T entity)
        {
            IRestClient client = new RestClient(baseUrl);

            IRestRequest postRequest = new RestRequest("data/Search/SearchingMeeting", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await client.ExecuteAsync(postRequest);
            
            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }
        
        public virtual async Task<T> InsertAsync(T entity)
        {
            IRestClient client = new RestClient(baseUrl);

            IRestRequest postRequest = new RestRequest("data/SelfKios/NewMeeting", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await client.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }
        

        //public virtual async Task<T> NotifyAsync(T entity)
        //{
        //    IRestClient client = new RestClient(baseUrl);

        //    IRestRequest postRequest = new RestRequest("data/SelfKios/NotifyEmployee", HttpMethod.POST);
        //    postRequest.RequestFormat = RequestDataFormat.Json;

        //    postRequest.AddBody(entity);
        //    IRestResponse postResponse = await client.ExecuteAsync(postRequest);

        //    T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

        //    return data;
        //}

        public virtual async Task<T> NotifyEmailAsync(T entity)
        {
            IRestClient client = new RestClient(baseUrl);

            IRestRequest postRequest = new RestRequest("data/SelfKios/NotifyEmailEmployee", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await client.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }
        

        #endregion
    }
}