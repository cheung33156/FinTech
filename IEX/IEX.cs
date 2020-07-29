// Copyright 2020 Tsz Ning Cheung 
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;


namespace IEX
{
    namespace Search
    {
        public class Result
        {
            [JsonProperty("symbol")]
            public string Symbol { get; set; }
            [JsonProperty("securityName")]
            public string SecurityName { get; set; }
            [JsonProperty("securityType")]
            public string SecurityType { get; set; }
            [JsonProperty("region")]
            public string Region { get; set; }
            [JsonProperty("exchange")]
            public string Exchange { get; set; }
        }
        public class Results : List<Result>
        {
            public new string ToString()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
        }
        class Request
        {
            public string Token { get; set; }
            public string Command { get; set; }
            public string Fragment { get; set; }
        }
        public class FluentRequest
        {
            private Request request = new Request();
            public FluentRequest Token(string token)
            {
                request.Token = token;
                return this;
            }
            public FluentRequest Command(string command)
            {
                request.Command = command;
                return this;
            }
            public FluentRequest Fragment(string fragment)
            {
                request.Fragment = fragment;
                return this;
            }
            public new string ToString()
            {
                return request.ToString();
            }
            public Results Execute()
            {
                const string urlBase = "https://sandbox.iexapis.com/stable/";

                string Url = String.Format("{0}/{1}/{2}?token={3}",
                                urlBase,
                                request.Command,
                                request.Fragment,
                                request.Token);

                var client = new RestClient(Url);
                var restRequest = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(restRequest);

                Results results = JsonConvert.DeserializeObject<Results>(response.Content);

                return results;
            }

        }
    }


    namespace Company
    {
        public class Result
        {
            [JsonProperty("symbol")]
            public string Symbol { get; set; }
            [JsonProperty("companyName")]
            public string CompanyName { get; set; }
            [JsonProperty("employees")]
            public int Employees { get; set; }
            [JsonProperty("exchange")]
            public string Exchange { get; set; }
            [JsonProperty("industry")]
            public string Industry { get; set; }
            [JsonProperty("website")]
            public string Website { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("CEO")]
            public int CEO { get; set; }
            [JsonProperty("securityName")]
            public string SecurityName { get; set; }
            [JsonProperty("issueType")]
            public string IssueType { get; set; }
            [JsonProperty("sector")]
            public string Sector { get; set; }
            [JsonProperty("primarySicCode")]
            public string PrimarySicCode { get; set; }
            [JsonProperty("tags")]
            public string[] Tags { get; set; }
            [JsonProperty("address")]
            public string Address { get; set; }
            [JsonProperty("state")]
            public string State { get; set; }
            [JsonProperty("city")]
            public string City { get; set; }
            [JsonProperty("zip")]
            public string Zip { get; set; }
            [JsonProperty("country")]
            public string Country { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
        }

    }
}