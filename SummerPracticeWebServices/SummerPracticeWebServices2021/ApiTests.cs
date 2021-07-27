using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using SummerPracticeWebServices2021.ApiModel;
using SummerPracticeWebServices2021.ApiService;

namespace SummerPracticeWebServices2021
{
    public class Tests
    {
        private string endpoint = "https://gcountries.getsandbox.com/countries";

        [Test]
        public void GetCountries()
        {
            var _response = ApiMethods.GetMethod(endpoint);

            Assert.AreEqual(HttpStatusCode.OK,_response.StatusCode);

            List<CountryModel> countryModel = JsonConvert.DeserializeObject<List<CountryModel>>(_response.Content);

            Assert.IsTrue(countryModel[0].Name.Equals("Italy"));

        }
        [Test]
        public void AddCountry()
        {
            const string body =
                "{\"name\":\"Italy9\",\"visited\":\"yes\",\"description\":\"The most beautiful\",\"url\":\"www.italia.com\"}";
            var _response = ApiMethods.PostMethods(endpoint, body);

            Assert.AreEqual(HttpStatusCode.Created,_response.StatusCode);

            ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(_response.Content);

            Assert.IsTrue(responseModel.Details.Contains("Italy9 successfully added to list"));
        }
        [Test]
        public void DeleteCountry()
        {
            var deleteEndpoint = endpoint + "/Italy";
            var _response = ApiMethods.DeleteMethod(deleteEndpoint);

            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);

            ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(_response.Content);

            Assert.IsTrue(responseModel.Details.Contains("Italy has been removed successfully"));

        }

        [Test]
        public void UpdateCountry()
        {
            var putEndpoint = endpoint + "/Country";

            const string body =
                "{\"name\":\"Country\",\"visited\":\"no\",\"description\":\"The most beautiful\",\"url\":\"www.italia.com\"}";

            var _response = ApiMethods.PutMethods(putEndpoint, body);

            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);

            ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(_response.Content);

            Assert.IsTrue(responseModel.Details.Contains("AnaCountry has been updated successfully"));

        }
    }
}