﻿using Intersoft.Crosslight;
using Intersoft.Crosslight.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Receiptionist.ModelServices;


namespace Receiptionist.Core.ModelServices
{
    public class RepositoryBase<T> : IRepository<T> where T : class , new()
    {

        #region Fields

        private string baseUrl = "http://192.168.0.65:58360";

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
        

        public virtual async Task<T> NotifyAsync(T entity)
        {
            IRestClient client = new RestClient(baseUrl);

            IRestRequest postRequest = new RestRequest("data/SelfKios/NotifyEmployee", HttpMethod.POST);
            postRequest.RequestFormat = RequestDataFormat.Json;

            postRequest.AddBody(entity);
            IRestResponse postResponse = await client.ExecuteAsync(postRequest);

            T data = SimpleJson.DeserializeObject<T>(postResponse.Content);

            return data;
        }

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