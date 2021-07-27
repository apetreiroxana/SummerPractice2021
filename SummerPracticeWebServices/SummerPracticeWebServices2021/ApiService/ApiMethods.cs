using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using RestSharp;

namespace SummerPracticeWebServices2021.ApiService
{
    public class ApiMethods
    {
        public static IRestResponse GetMethod(string requestUrl)
        {
            var restClient = new RestClient(requestUrl);

            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var response = restClient.Execute(request);

            return response;
        }

        public static IRestResponse PostMethods(string requestUrl, string body)
        {
            var restClient = new RestClient(requestUrl);

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/body", body, ParameterType.RequestBody);

            var response = restClient.Execute(request);

            return response;

        }

        public static IRestResponse DeleteMethod(string requestUrl)
        {
            var restClient = new RestClient(requestUrl);

            var request = new RestRequest(Method.DELETE);

            request.AddHeader("Content-Type", "application/json");

            var response = restClient.Execute(request);

            return response;

        }

        public static IRestResponse PutMethods(string requestUrl, string body)
        {
            var restClient = new RestClient(requestUrl);

            var request = new RestRequest(Method.PUT);

            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/body", body, ParameterType.RequestBody);

            var response = restClient.Execute(request);

            return response;

        }

    }
}
